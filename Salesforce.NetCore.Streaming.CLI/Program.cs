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
        // TODO:  Accept command line parameters for event channel (required) and replayId (optional)

        // TODO:  Use replay feature to capture changes

        // TODO:  Tighten up code, add comments

        // TODO:  Check the DictionaryMessage (Advice property) for any error messages connecting during handshake
        //         and throw an exception for those.

        // TODO:  Update blog on how to create a Push Topic

        [Required]
        [Option("-c|--channel", Description = "Event bus channel to subscribe to.")]
        public string Channel { get; }

        [Option("-r|--replay", Description = "ReplayId for starting point.")]
        public string ReplayId { get; }


        public static Task<int> Main(string[] args) => CommandLineApplication.ExecuteAsync<Program>(args);

        private async Task OnExecuteAsync()
        {
            var host = new HostBuilder()
                 .ConfigureHostSettings()
                 .ConfigureHostServices(new CommandLineOptions(Channel, ReplayId))
                 .ConfigureHostLogging()
                 .UseConsoleLifetime()
                 .Build();

            await host.RunAsync();
        }
    }
}

