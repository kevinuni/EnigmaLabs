﻿using Newtonsoft.Json;

namespace ConsoleTest.TestWialon
{
    public class Datum
    {
        [JsonProperty("ID Nation")]
        public string IDNation { get; set; }

        public string Nation { get; set; }

        [JsonProperty("ID Year")]
        public int IDYear { get; set; }

        public string Year { get; set; }
        public int Population { get; set; }

        [JsonProperty("Slug Nation")]
        public string SlugNation { get; set; }
    }
}