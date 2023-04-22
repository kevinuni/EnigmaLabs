using Enigma.Util;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpManager manager = HttpManager.Instance();

            #region [GET]

            var par = new Dictionary<string, string>();
            par.Add("test", "123");

            var resultGet = Task<GetObject>.Run(() =>
            {
                return manager.Get<GetObject>("https://postman-echo.com/get", par);
            });

            GetObject getObject = resultGet.GetAwaiter().GetResult();

            #endregion [GET]

            #region [POST]

            var resultPost = Task<PostObject>.Run(() =>
            {
                return manager.Post<string, PostObject>("https://postman-echo.com/post", "texto de prueba");
            });

            PostObject postObject = resultPost.GetAwaiter().GetResult();

            #endregion [POST]


        }
    }
}
