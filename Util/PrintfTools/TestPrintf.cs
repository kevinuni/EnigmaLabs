using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Util.PrintfTools
{
    public class TestPrintf
    {
        public void test()
        {
            //string result = MsvcrtWrapper.sprintf("%s %s", "hola", "mundo");
            //Console.WriteLine(result);

            float y = 4.5F;
            double w = 1.7E+3;

            StringBuilder sb1 = new StringBuilder();
            sprintf(sb1, "%s %.5f mundo", __arglist("hola", y));  //w ok
            Console.WriteLine(sb1.ToString());

            StringBuilder sb2 = new StringBuilder();
            sprintf(sb2, "%s %.5f mundo", "hola", y);
            Console.WriteLine(sb2.ToString());
        }

        // When calling with any variable parameters and Ansi
        [DllImport("msvcr100.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sprintf(StringBuilder buffer, string format, __arglist);

        //// When calling with any variable parameters and Unicode
        //[DllImport("msvcrt.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int swprintf(StringBuilder buffer, string format, __arglist);

        //// When calling with 1 arg
        //[DllImport("msvcrt.Dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int sprintf([In, Out]StringBuilder buffer, String fmt, String arg1);

        //// When calling with 2 args
        //[DllImport("msvcrt.Dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int sprintf([In, Out]StringBuilder buffer, String fmt, String arg1, String arg2);

        // When calling with 2 args
        [DllImport("msvcr100.Dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int sprintf([In, Out] StringBuilder buffer, String fmt, String arg1, float arg2);

        //// When calling with 3 args
        //[DllImport("msvcrt.Dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int sprintf([In, Out]StringBuilder buffer, String fmt, String arg1, String arg2, String arg3);
    }
}