using BlackBeltCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Util
{
    [Serializable]
    public class PrintfNetDemo
    {
        public static string sprintf(string Format, params object[] Parameters)
        {
            return PrintfNet.sprintf(Format, Parameters);
        }

        public static void fprintf(StreamWriter Destination, string Format, params object[] Parameters)
        {
            string s = PrintfNet.sprintf(Format, Parameters);
            Destination.Write(s);
            Destination.Flush();
        }

    }
}
