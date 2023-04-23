using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleTest.TestWialonApi
{
    public class Pos
    {
        [JsonPropertyName("x")]
        public double x { get; set; }

        [JsonPropertyName("c")]
        public int c { get; set; }

        [JsonPropertyName("y")]
        public double y { get; set; }

        [JsonPropertyName("s")]
        public int s { get; set; }
    }
}
