using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;
using Salesforce.NetCore.Streaming.CLI.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Salesforce.NetCore.Streaming.CLI
{
    [HelpOption("-?")]
    class Program
    {
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

