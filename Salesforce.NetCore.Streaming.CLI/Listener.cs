using Cometd.Bayeux;
using Cometd.Bayeux.Client;
using Cometd.Client;
using Microsoft.Extensions.Logging;
using System;

namespace Salesforce.NetCore.Streaming.CLI
{
    class Listener : IMessageListener
    {
        private readonly ILogger logger;

        public Listener(ILogger logger)
        {
            this.logger = logger;
        }

        public void onMessage(IClientSessionChannel channel, IMessage message)
        {
            logger.LogInformation(message.JSON);
        }
    }
}
