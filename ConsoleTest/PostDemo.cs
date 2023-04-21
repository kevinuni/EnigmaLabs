using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Args
    {
        public string test { get; set; }
    }

    public class Headers
    {
        [JsonProperty("x-forwarded-proto")]
        public string xforwardedproto { get; set; }

        [JsonProperty("x-forwarded-port")]
        public string xforwardedport { get; set; }
        public string host { get; set; }

        [JsonProperty("x-amzn-trace-id")]
        public string xamzntraceid { get; set; }

        [JsonProperty("user-agent")]
        public string useragent { get; set; }
        public string accept { get; set; }

        [JsonProperty("postman-token")]
        public string postmantoken { get; set; }

        [JsonProperty("accept-encoding")]
        public string acceptencoding { get; set; }
        public string cookie { get; set; }
    }

    public class Root
    {
        public Args args { get; set; }
        public Headers headers { get; set; }
        public string url { get; set; }
    }


}