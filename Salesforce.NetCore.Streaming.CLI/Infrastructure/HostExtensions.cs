using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Salesforce.NetCore.Streaming.CLI.Infrastructure
{
    public static class HostExtensions
    {
        public static IHostBuilder ConfigureHostServices(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddLogging();
                services.AddHttpClient<SalesforceClient>();
                services.AddHostedService<SalesforceStreamingService>();
                services.Configure<SalesforceConfig>(options => context.Configuration.GetSection("Salesforce").Bind(options));

            });
            return builder;
        }

        public static IHostBuilder ConfigureHostSettings(this IHostBuilder builder)
        {
            builder.ConfigureHostConfiguration(configHost =>
            {
                configHost.SetBasePath(Directory.GetCurrentDirectory());
                configHost.AddJsonFile("hostsettings.json", optional: true);
                configHost.AddEnvironmentVariables(prefix: "PREFIX_");
            });
            builder.ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                configBuilder.AddEnvironmentVariables(prefix: "PREFIX_");
                configBuilder.AddUserSecrets<Program>();
            });
            return builder;
        }

        public static IHostBuilder ConfigureHostLogging(this IHostBuilder builder)
        {
            return builder.ConfigureLogging((hostContext, configLogging) =>
            {
                configLogging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                configLogging.AddConsole();
                configLogging.AddDebug();
            });
        }
    }
}
