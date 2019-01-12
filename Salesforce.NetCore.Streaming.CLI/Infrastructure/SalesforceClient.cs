using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Salesforce.NetCore.Streaming.CLI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.NetCore.Streaming.CLI.Infrastructure
{
    public class SalesforceClient
    {
        private HttpClient client;
        private readonly SalesforceConfig configuration;

        public SalesforceClient(HttpClient httpClient, IOptions<SalesforceConfig> configurationOptions)
        {
            client = httpClient;
            this.configuration = configurationOptions.Value;
        }

        public async Task<AuthToken> GetToken()
        {
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("grant_type", configuration.GrantType));
            nvc.Add(new KeyValuePair<string, string>("client_id", configuration.ClientId));
            nvc.Add(new KeyValuePair<string, string>("client_secret", configuration.ClientSecret));
            nvc.Add(new KeyValuePair<string, string>("username", configuration.Username));
            nvc.Add(new KeyValuePair<string, string>("password", configuration.Password + configuration.UserSecurityToken));

            var req = new HttpRequestMessage(HttpMethod.Post, configuration.LoginUrl) { Content = new FormUrlEncodedContent(nvc) };
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthToken>(content);
        }
    }
}
