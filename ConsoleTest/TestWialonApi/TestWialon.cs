using Enigma.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.TestWialon
{
    internal class TestWialon
    {
        public async Task<string> GetWialon()
        {
            HttpManager helper = HttpManager.Instance();
            helper.InitializeClient("https://nimbus.wialon.com/api/");
            //var content = helper.GrantTypeByPassword("user", "password");
            //await helper.GenerateToken(content);
            //Console.WriteLine(helper.Token);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Token 39d40f3eef2d4deb993eefcd4498a5c5");

            var result = await helper.Get<string>("depots", null, headers);

            return result.Data;
        }
    }
}
