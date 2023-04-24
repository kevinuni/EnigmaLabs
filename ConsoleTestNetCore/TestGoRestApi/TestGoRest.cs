using Enigma.Util;
using System.Threading.Tasks;

namespace ConsoleTest.TestGoRestApi;

internal class TestGoRest
{
    public async void Run()
    {
        HttpManager httpManager = HttpManager.Instance();
        httpManager.InitializeClient("https://gorest.co.in/");
        //var token = "d3f5acbe3304400d2ba5bf9360b9553a8721148604536a7dcddf680f99c20de5";
        //helper.Token = token;

        var resultGet = await httpManager.Post<dynamic>("public/v2/users", null);
    }
}