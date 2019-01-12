using Microsoft.Extensions.Hosting;
using Salesforce.NetCore.Streaming.CLI.Infrastructure;
using System.Threading.Tasks;

namespace Salesforce.NetCore.Streaming.CLI
{
    class Program
    {
        // TODO:  Update blog on how to create a Push Topic

        // TODO:  Store Audit log of records 

        // TODO:  Use replay feature to capture changes

        // TODO:  Job to purge records over X days old.

        // TODO:  Check the DictionaryMessage (Advice property) for any error messages connecting during handshake
        //         and throw an exception for those.

        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                 .ConfigureHostSettings()
                 .ConfigureHostServices()
                 .ConfigureHostLogging()
                 .UseConsoleLifetime()
                 .Build();

            await host.RunAsync();
        }
    }
}

