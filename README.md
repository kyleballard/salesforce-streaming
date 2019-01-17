# Salesforce.NetCore.Streaming.CLI

This project is an accelerator for developing applications that subscribe to the [Streaming API](https://developer.salesforce.com/docs/atlas.en-us.api_streaming.meta/api_streaming/) from Salesforce.  This includes Push Topics, Change Data Capture, generic events, and platform events.

There is a full write-up to support this repository [available at my blog](https://www.ballardsoftware.com/getting-started-with-the-salesforce-streaming-api-in-net-core).

## Prerequisites

* .NET Core 2.1+
* Visual Studio 2017+ / Visual Studio Code

## Setup

After cloning the repository, you'll need to update the appsettings.json file with your configuration values.   I strongly recommend using User Secrets, Envrionment variables, or Azure Key Vault for safe storage of several of the configuration parameters.
 
## Credits

The [CometD.NET Library](https://github.com/Oyatel/CometD.NET) in this project is one which works on versions of .NET prior to Core.  I made alterations to this, primarily around how Json serialization works to make it compatible with .NET Core.  Some additional modifications were also made to the library to enhance it.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)