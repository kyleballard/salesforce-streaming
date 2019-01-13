using Microsoft.Extensions.Hosting;
using Salesforce.NetCore.Streaming.CLI.Infrastructure;
using System.Threading.Tasks;

namespace Salesforce.NetCore.Streaming.CLI
{
    class Program
    {
        // TODO:  Fix timeout issue with LongPollingTransport line 245

        // TODO:  Accept command line parameters for event channel (required) and replayId (optional)

        // TODO:  Use replay feature to capture changes

        // TODO:  Tighten up code, add comments

        // TODO:  Check the DictionaryMessage (Advice property) for any error messages connecting during handshake
        //         and throw an exception for those.

        // TODO:  Update blog on how to create a Push Topic

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

