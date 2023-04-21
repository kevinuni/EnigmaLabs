using Enigma.Util;
using System;
using System.Collections.Generic;
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

            var par = new Dictionary<string, string>();
            par.Add("test", "123");

            var result = Task<Root>.Run(() =>
            {
                return manager.Get<Root>("https://postman-echo.com/get", par);
            });

            Root root = result.GetAwaiter().GetResult();

            dynamic param = new { test = "123" };

        }
    }
}
