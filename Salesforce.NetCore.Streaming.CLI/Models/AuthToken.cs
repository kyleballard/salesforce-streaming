using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salesforce.NetCore.Streaming.CLI.Models
{
    public class AuthToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; }
        [JsonProperty("instance_url")]
        public string InstanceUrl { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("issued_at")]
        public string IssuedAt { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
