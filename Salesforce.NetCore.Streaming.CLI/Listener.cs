using Cometd.Bayeux;
using Cometd.Bayeux.Client;
using Cometd.Client;
using System;

namespace Salesforce.NetCore.Streaming.CLI
{
    class Listener : IMessageListener
    {
        public void onMessage(IClientSessionChannel channel, IMessage message)
        {
            Console.WriteLine(message.JSON);
        }
    }
}
