using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Enigma.Util
{

    [Serializable]
    public class ScanfWrapper
    {
        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sscanf(string buffer, string format, ref int arg0);

        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sscanf(string buffer, string format, ref int arg0, ref int arg1);

        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sscanf(string buffer, string format, ref int arg0, ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5, ref int arg6, ref int arg7, ref int arg8, ref int arg9, ref int arg10, ref int arg11);

        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sscanf(string buffer, string format, ref int var0, ref float arg0, ref float arg1, ref float arg2, ref float arg3, ref float arg4, ref float arg5, ref float arg6, ref float arg7, ref float arg8, ref float arg9, ref float arg10, ref float arg11);

        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sscanf(string buffer, string format, ref int arg0, ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5, ref int arg6, ref int arg7, ref int arg8, ref int arg9, ref int arg10, ref int arg11, ref int arg12, ref int arg13, ref int arg14, ref int arg15, ref int arg16, ref int arg17, ref int arg18, ref int arg19, ref int arg20, ref int arg21, ref int arg22, ref int arg23, ref int arg24, ref int arg25, ref int arg26, ref int arg27, ref int arg28, ref int arg29, ref int arg30, ref int arg31, ref int arg32);

        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sscanf(string buffer, string format, ref double arg0);

        [DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sscanf(string buffer, string format, ref int arg0, ref double arg1, ref double arg2, ref double arg3, ref double arg4, ref double arg5, ref double arg6, ref double arg7, ref double arg8, ref double arg9, ref double arg10, ref double arg11, ref double arg12);


        ////[DllImport("msvcrt.dll", SetLastError = false,  CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        ////public static extern int sprintf(StringBuilder buff, string format, __arglist);


        //// When calling with any variable parameters and Ansi
        //[DllImport("msvcrt.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //static extern int sprintf(StringBuilder buffer, string format, __arglist);


        //// When calling with any variable parameters and Unicode
        //[DllImport("msvcrt.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        //static extern int swprintf(StringBuilder buffer, string format, __arglist);

        //// When calling with 1 arg
        //[DllImport("msvcrt.Dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern int sprintf([In, Out]StringBuilder buffer, String fmt, String arg1);

        //// When calling with 2 args
        //[DllImport("msvcrt.Dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern int sprintf([In, Out]StringBuilder buffer, String fmt, String arg1, String arg2);

        //// When calling with 3 args
        //[DllImport("msvcrt.Dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern int sprintf([In, Out]StringBuilder buffer, String fmt, String arg1, String arg2, String arg3);

    }
}
