using Enigma.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleTest.TestWialon
{
    internal class TestWialon
    {
        public static void Run()
        {
            HttpManager httpManager = HttpManager.Instance();
            httpManager.InitializeClient("https://nimbus.wialon.com/api/");
            //var content = helper.GrantTypeByPassword("user", "password");
            //await helper.GenerateToken(content);
            //Console.WriteLine(helper.Token);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Token 39d40f3eef2d4deb993eefcd4498a5c5");

            var resultGet = Task<string>.Run(() =>
            {
                return httpManager.Get<string>("depots", null, headers);
            });

            Reply<string> getObject = resultGet.GetAwaiter().GetResult();
        }
    }
}