using Enigma.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleTest.TestPostmanApi
{
    internal class TestPostman
    {
        public static void Run()
        {
            HttpManager httpManager = HttpManager.Instance();
            httpManager.InitializeClient("https://postman-echo.com");
            var par = new Dictionary<string, string>();
            par.Add("test", "123");
            var resultGet = httpManager.GetAsync<GetObject>("get", par);
            var replyGet = resultGet.GetAwaiter().GetResult();
            GetObject dataGet = replyGet.Data;

            var resultPost = httpManager.PostAsync<string, PostObject>("/post", "texto de prueba");
            var replyPost = resultPost.GetAwaiter().GetResult();
            PostObject dataPost = replyPost.Data;
        }
    }
}