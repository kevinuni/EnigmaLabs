namespace ConsoleTest.TestPostmanApi
{
    public class PostObject
    {
        public Args args { get; set; }
        public string data { get; set; }
        public Files files { get; set; }
        public Form form { get; set; }
        public Headers headers { get; set; }
        public object json { get; set; }
        public string url { get; set; }
    }
}