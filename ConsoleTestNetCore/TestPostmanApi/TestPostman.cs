using Enigma.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleTest.TestPostmanApi
{
    internal class TestPostman
    {
        public async void Run()
        {
            HttpManager httpManager = HttpManager.Instance();
            httpManager.InitializeClient("https://postman-echo.com");
            var par = new Dictionary<string, string>();
            par.Add("test", "123");
            
            var resultGet = await httpManager.Get<GetObject>("get", par);

            var resultPost = await httpManager.Post<PostObject>("/post", "texto de prueba");
            
        }
    }
}