using Cometd.Client;
using Cometd.Client.Transport;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Salesforce.NetCore.Streaming.CLI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace Salesforce.NetCore.Streaming.CLI
{
    internal class SalesforceStreamingService : IHostedService
    {
        private readonly ILogger logger;
        private readonly IApplicationLifetime appLifetime;
        private readonly SalesforceClient salesforceClient;
        private readonly SalesforceConfig sfOptions;
        private BayeuxClient bayeuxClient;
        private int readTimeOut = 120 * 1000;

        public SalesforceStreamingService(
            ILogger<SalesforceStreamingService> logger, IApplicationLifetime appLifetime,
            IOptions<SalesforceConfig> sfOptions, SalesforceClient salesforceClient)
        {
            this.logger = logger;
            this.appLifetime = appLifetime;
            this.salesforceClient = salesforceClient;
            this.sfOptions = sfOptions.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);

            logger.LogInformation("SalesforceStreamingService.StartAsync has been called.");

            logger.LogInformation("Authenticating with Salesforce...");
            var authToken = await salesforceClient.GetToken();

            logger.LogInformation("Enabling Bayeux protocol...");
            var options = new Dictionary<String, Object>
            {
               { ClientTransport.TIMEOUT_OPTION, readTimeOut }
            };
            var transport = new LongPollingTransport(options);

            // add the needed auth headers
            var headers = new NameValueCollection();
            headers.Add("Authorization", "OAuth " + authToken.AccessToken);
            transport.AddHeaders(headers);

            // only need the scheme and host, strip out the rest
            var serverUri = new Uri(authToken.InstanceUrl);
            String endpoint = String.Format("{0}://{1}{2}", serverUri.Scheme, serverUri.Host, sfOptions.StreamEndpoint);
            bayeuxClient = new BayeuxClient(endpoint, new[] { transport });

            logger.LogInformation("Handshaking with Salesforce stream...");
            bayeuxClient.handshake();
            bayeuxClient.waitFor(1000, new[] { BayeuxClient.State.CONNECTED });

            logger.LogInformation("Connected to Salesforce stream...");

            bayeuxClient.getChannel(sfOptions.Channel).subscribe(new Listener(logger));
            logger.LogInformation("Waiting for data from server...");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            // TODO:  Update BayeuxClient library to use async methods
            await Task.Factory.StartNew(() =>
            {
                logger.LogInformation("SalesforceStreamingService.StopAsync has been called.");
                logger.LogInformation("Disconnecting from Salesforce...");
                bayeuxClient.disconnect();
                bayeuxClient.waitFor(1000, new[] { BayeuxClient.State.DISCONNECTED });
            });
        }

        private void OnStarted()
        {
            logger.LogInformation("SalesforceStreamingService.OnStarted has been called.");
            // Perform post-startup activities here
        }

        private void OnStopping()
        {
            logger.LogInformation("SalesforceStreamingService.OnStopping has been called.");
            // Perform on-stopping activities here
        }

        private void OnStopped()
        {
            logger.LogInformation("SalesforceStreamingService.OnStopped has been called.");
            // Perform post-stopped activities here
        }
    }
}
