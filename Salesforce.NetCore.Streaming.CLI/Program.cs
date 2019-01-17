using Microsoft.Extensions.Hosting;
using Salesforce.NetCore.Streaming.CLI.Infrastructure;
using System.Threading.Tasks;

namespace Salesforce.NetCore.Streaming.CLI
{
    class Program
    {
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

