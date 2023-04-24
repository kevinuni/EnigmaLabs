using System.Net.Http;
using System.Net.Http.Headers;

namespace Enigma.Util
{
    public class Reply<T>
    {
        public string StatusCode { get; set; }
        public HttpResponseMessage Response { get; set; }        
        public T Data { get; set; }
    }
}