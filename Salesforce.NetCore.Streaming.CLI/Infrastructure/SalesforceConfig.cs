using System;
using System.Collections.Generic;
using System.Text;

namespace Salesforce.NetCore.Streaming.CLI.Infrastructure
{
    public class SalesforceConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserSecurityToken { get; set; }
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string LoginUrl { get; set; }
        public string StreamEndpoint { get; set; }
    }
}
