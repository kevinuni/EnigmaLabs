using Enigma.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.TestGoRest
{
    internal class TestGoRest
    {
        public async Task<dynamic> GetGoRest()
        {
            HttpManager helper = HttpManager.Instance();
            helper.InitializeClient("https://gorest.co.in/");
            //var token = "d3f5acbe3304400d2ba5bf9360b9553a8721148604536a7dcddf680f99c20de5";
            //helper.Token = token;

            var result = await helper.Post<object, dynamic>("/public/v2/users", null);
            return result;
        }
    }
}
