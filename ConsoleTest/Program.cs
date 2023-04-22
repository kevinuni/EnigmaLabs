﻿using Enigma.Util;
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
            HttpManager httpManager = HttpManager.Instance();

            #region [GET]

            var par = new Dictionary<string, string>();
            par.Add("test", "123");

            var resultGet = Task<GetObject>.Run(() =>
            {
                return httpManager.Get<GetObject>("https://postman-echo.com/get", par);
            });

            Reply<GetObject> getObject = resultGet.GetAwaiter().GetResult();

            #endregion [GET]

            #region [POST]

            var resultPost = Task<PostObject>.Run(() =>
            {
                return httpManager.Post<string, PostObject>("https://postman-echo.com/post", "texto de prueba");
            });

            Reply<PostObject> postObject = resultPost.GetAwaiter().GetResult();

            #endregion [POST]
        }
    }
}
