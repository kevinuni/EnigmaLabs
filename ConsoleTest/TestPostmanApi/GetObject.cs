using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.TestPostmanApi
{
    public class GetObject
    {
        public Args args { get; set; }
        public Headers headers { get; set; }
        public string url { get; set; }
    }
}