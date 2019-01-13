namespace Salesforce.NetCore.Streaming.CLI.Infrastructure
{
    public class CommandLineOptions
    {
        public string Channel { get; set; }
        public string ReplayId { get; set; }

        public CommandLineOptions()
        { }

        public CommandLineOptions(string channel, string replayId)
        {
            this.Channel = channel;
            this.ReplayId = replayId;
        }
    }
}
