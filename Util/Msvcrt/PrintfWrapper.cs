using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class PrintfWrapper
    {
        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern int sprintf(StringBuilder buff, string format, double p0);
        public static string sprintf(string format, double p0)
        {
            StringBuilder buff = new StringBuilder();
            sprintf(buff, format, p0);
            return buff.ToString();
        }


        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern int sprintf(StringBuilder buff, string format, int p0);
        public static string sprintf(string format, int p0)
        {
            StringBuilder buff = new StringBuilder();
            sprintf(buff, format, p0);
            return buff.ToString();
        }


        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern int sprintf(StringBuilder buff, string format, string p0, int p1);
        public static string sprintf(string format, string p0, int p1)
        {
            StringBuilder buff = new StringBuilder();
            sprintf(buff, format, p0, p1);
            return buff.ToString();
        }

        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern int sprintf(StringBuilder buff, string format, int p0, double p1);
        public static string sprintf(string format, int p0, double p1)
        {
            StringBuilder buff = new StringBuilder();
            sprintf(buff, format, p0, p1);
            return buff.ToString();
        }

        [DllImport("msvcrt.dll", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern int sprintf(StringBuilder buff, string format, string p0, string p1);
        public static string sprintf(string format, string p0, string p1)
        {
            StringBuilder buff = new StringBuilder();
            sprintf(buff, format, p0, p1);
            return buff.ToString();
        }



        //#region [sprintf]

        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sprintf(StringBuilder buff, string format, __arglist);

        //#region[swprintf]

        //// When calling with any variable parameters and Unicode
        //[DllImport("msvcrt.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int swprintf(StringBuilder buffer, string format, __arglist);


        //#endregion[swprintf]

        //[DllImport("msvcrt40.dll")]
        //public static extern int printf(string format, __arglist);
    }
}
