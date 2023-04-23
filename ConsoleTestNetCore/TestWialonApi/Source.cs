using System.Collections.Generic;

namespace ConsoleTest.TestWialon
{
    public class Source
    {
        public List<string> measures { get; set; }
        public Annotations annotations { get; set; }
        public string name { get; set; }
        public List<object> substitutions { get; set; }
    }
}