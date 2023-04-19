using BlackBeltCoder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    internal class ScanfNet
    {
        public static int sscanf(string buffer, string format, ref int arg0)
        {
            //"%d"
            int result = 0;

            if (!string.IsNullOrWhiteSpace(buffer))
            {
                ScanFormatted parser = new ScanFormatted();
                int count = parser.Parse(buffer, format);
                if (parser.Results.Count > 0) 
                    arg0 = (int)parser.Results[0];
                result = 0;
            }
            else
            {
                result = -1;
            }

            int v_arg0 = 0;
            Util.ScanfWrapper.sscanf(buffer, format, ref v_arg0);
            Debug.Assert(arg0 == v_arg0, "warning wrapper");

            return result;
        }

        public static int sscanf(string buffer, string format, ref int arg0, ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5, ref int arg6, ref int arg7, ref int arg8, ref int arg9, ref int arg10, ref int arg11, ref int arg12, ref int arg13, ref int arg14, ref int arg15, ref int arg16, ref int arg17, ref int arg18, ref int arg19, ref int arg20, ref int arg21, ref int arg22, ref int arg23, ref int arg24, ref int arg25, ref int arg26, ref int arg27, ref int arg28, ref int arg29, ref int arg30, ref int arg31, ref int arg32)
        {
            //"%d%d%d%d %d%d%d%d %d%d%d%d %d%d%d%d %d%d%d%d %d%d%d%d %d%d%d%d %d%d%d%d %d"
            int result = 0;

            if (!string.IsNullOrWhiteSpace(buffer))
            {
                ScanFormatted parser = new ScanFormatted();
                int count = parser.Parse(buffer, format);

                if (parser.Results.Count > 0) arg0 = (int)parser.Results[0];
                if (parser.Results.Count > 1) arg1 = (int)parser.Results[1];
                if (parser.Results.Count > 2) arg2 = (int)parser.Results[2];
                if (parser.Results.Count > 3) arg3 = (int)parser.Results[3];
                if (parser.Results.Count > 4) arg4 = (int)parser.Results[4];
                if (parser.Results.Count > 5) arg5 = (int)parser.Results[5];
                if (parser.Results.Count > 6) arg6 = (int)parser.Results[6];
                if (parser.Results.Count > 7) arg7 = (int)parser.Results[7];
                if (parser.Results.Count > 8) arg8 = (int)parser.Results[8];
                if (parser.Results.Count > 9) arg9 = (int)parser.Results[9];
                if (parser.Results.Count > 10) arg10 = (int)parser.Results[10];
                if (parser.Results.Count > 11) arg11 = (int)parser.Results[11];
                if (parser.Results.Count > 12) arg12 = (int)parser.Results[12];
                if (parser.Results.Count > 13) arg13 = (int)parser.Results[13];
                if (parser.Results.Count > 14) arg14 = (int)parser.Results[14];
                if (parser.Results.Count > 15) arg15 = (int)parser.Results[15];
                if (parser.Results.Count > 16) arg16 = (int)parser.Results[16];
                if (parser.Results.Count > 17) arg17 = (int)parser.Results[17];
                if (parser.Results.Count > 18) arg18 = (int)parser.Results[18];
                if (parser.Results.Count > 19) arg19 = (int)parser.Results[19];
                if (parser.Results.Count > 20) arg20 = (int)parser.Results[20];
                if (parser.Results.Count > 21) arg21 = (int)parser.Results[21];
                if (parser.Results.Count > 22) arg22 = (int)parser.Results[22];
                if (parser.Results.Count > 23) arg23 = (int)parser.Results[23];
                if (parser.Results.Count > 24) arg24 = (int)parser.Results[24];
                if (parser.Results.Count > 25) arg25 = (int)parser.Results[25];
                if (parser.Results.Count > 26) arg26 = (int)parser.Results[26];
                if (parser.Results.Count > 27) arg27 = (int)parser.Results[27];
                if (parser.Results.Count > 28) arg28 = (int)parser.Results[28];
                if (parser.Results.Count > 29) arg29 = (int)parser.Results[29];
                if (parser.Results.Count > 30) arg30 = (int)parser.Results[30];
                if (parser.Results.Count > 31) arg31 = (int)parser.Results[31];
                if (parser.Results.Count > 32) arg32 = (int)parser.Results[32];
                result = 0;

            }
            else
            {
                result = -1;
            }

            int v_arg0 = 0;
            int v_arg1 = 0;
            int v_arg2 = 0;
            int v_arg3 = 0;
            int v_arg4 = 0;
            int v_arg5 = 0;
            int v_arg6 = 0;
            int v_arg7 = 0;
            int v_arg8 = 0;
            int v_arg9 = 0;
            int v_arg10 = 0;
            int v_arg11 = 0;
            int v_arg12 = 0;
            int v_arg13 = 0;
            int v_arg14 = 0;
            int v_arg15 = 0;
            int v_arg16 = 0;
            int v_arg17 = 0;
            int v_arg18 = 0;
            int v_arg19 = 0;
            int v_arg20 = 0;
            int v_arg21 = 0;
            int v_arg22 = 0;
            int v_arg23 = 0;
            int v_arg24 = 0;
            int v_arg25 = 0;
            int v_arg26 = 0;
            int v_arg27 = 0;
            int v_arg28 = 0;
            int v_arg29 = 0;
            int v_arg30 = 0;
            int v_arg31 = 0;
            int v_arg32 = 0;

            Util.ScanfWrapper.sscanf(buffer, format, ref v_arg0, ref v_arg1, ref v_arg2, ref v_arg3, ref v_arg4, ref v_arg5, ref v_arg6, ref v_arg7, ref v_arg8, ref v_arg9, ref v_arg10, ref v_arg11, ref v_arg12, ref v_arg13, ref v_arg14, ref v_arg15, ref v_arg16, ref v_arg17, ref v_arg18, ref v_arg19, ref v_arg20, ref v_arg21, ref v_arg22, ref v_arg23, ref v_arg24, ref v_arg25, ref v_arg26, ref v_arg27, ref v_arg28, ref v_arg29, ref v_arg30, ref v_arg31, ref v_arg32);

            Debug.Assert(arg0 == v_arg0, "warning wrapper");
            Debug.Assert(arg1 == v_arg1, "warning wrapper");
            Debug.Assert(arg2 == v_arg2, "warning wrapper");
            Debug.Assert(arg3 == v_arg3, "warning wrapper");
            Debug.Assert(arg4 == v_arg4, "warning wrapper");
            Debug.Assert(arg5 == v_arg5, "warning wrapper");
            Debug.Assert(arg6 == v_arg6, "warning wrapper");
            Debug.Assert(arg7 == v_arg7, "warning wrapper");
            Debug.Assert(arg8 == v_arg8, "warning wrapper");
            Debug.Assert(arg9 == v_arg9, "warning wrapper");
            Debug.Assert(arg10 == v_arg10, "warning wrapper");
            Debug.Assert(arg11 == v_arg11, "warning wrapper");
            Debug.Assert(arg12 == v_arg12, "warning wrapper");
            Debug.Assert(arg13 == v_arg13, "warning wrapper");
            Debug.Assert(arg14 == v_arg14, "warning wrapper");
            Debug.Assert(arg15 == v_arg15, "warning wrapper");
            Debug.Assert(arg16 == v_arg16, "warning wrapper");
            Debug.Assert(arg17 == v_arg17, "warning wrapper");
            Debug.Assert(arg18 == v_arg18, "warning wrapper");
            Debug.Assert(arg19 == v_arg19, "warning wrapper");
            Debug.Assert(arg20 == v_arg20, "warning wrapper");
            Debug.Assert(arg20 == v_arg10, "warning wrapper");
            Debug.Assert(arg21 == v_arg21, "warning wrapper");
            Debug.Assert(arg22 == v_arg22, "warning wrapper");
            Debug.Assert(arg23 == v_arg23, "warning wrapper");
            Debug.Assert(arg24 == v_arg24, "warning wrapper");
            Debug.Assert(arg25 == v_arg25, "warning wrapper");
            Debug.Assert(arg26 == v_arg26, "warning wrapper");
            Debug.Assert(arg27 == v_arg27, "warning wrapper");
            Debug.Assert(arg28 == v_arg28, "warning wrapper");
            Debug.Assert(arg29 == v_arg29, "warning wrapper");
            Debug.Assert(arg30 == v_arg30, "warning wrapper");
            Debug.Assert(arg31 == v_arg31, "warning wrapper");
            Debug.Assert(arg32 == v_arg32, "warning wrapper");

            return result;
        }

        public static int sscanf(string buffer, string format, ref double arg0)
        {
            //"%lf"
            int result = 0;

            if (!string.IsNullOrWhiteSpace(buffer))
            {
                ScanFormatted parser = new ScanFormatted();
                int count = parser.Parse(buffer, format);

                if (parser.Results.Count > 0) arg0 = (double)parser.Results[0];
                result = 0;
            }
            else
            {
                result = -1;
            }

            double v_arg0 = 0;
            Util.ScanfWrapper.sscanf(buffer, format, ref v_arg0);
            Debug.Assert(arg0 == v_arg0, "warning wrapper");

            return result;
        }

        public static int sscanf(string buffer, string format, ref int arg0, ref double arg1, ref double arg2, ref double arg3, ref double arg4, ref double arg5, ref double arg6, ref double arg7, ref double arg8, ref double arg9, ref double arg10, ref double arg11, ref double arg12)
        {
            //"%d %lf %lf %lf %lf %lf %lf %lf %lf %lf %lf %lf %lf"
            int result = 0;

            if (!string.IsNullOrWhiteSpace(buffer))
            {
                ScanFormatted parser = new ScanFormatted();
                int count = parser.Parse(buffer, format);


                if (parser.Results.Count > 0) arg0 = (int)parser.Results[0];
                if (parser.Results.Count > 1) arg1 = (double)parser.Results[1];
                if (parser.Results.Count > 2) arg2 = (double)parser.Results[2];
                if (parser.Results.Count > 3) arg3 = (double)parser.Results[3];
                if (parser.Results.Count > 4) arg4 = (double)parser.Results[4];
                if (parser.Results.Count > 5) arg5 = (double)parser.Results[5];
                if (parser.Results.Count > 6) arg6 = (double)parser.Results[6];
                if (parser.Results.Count > 7) arg7 = (double)parser.Results[7];
                if (parser.Results.Count > 8) arg8 = (double)parser.Results[8];
                if (parser.Results.Count > 9) arg9 = (double)parser.Results[9];
                if (parser.Results.Count > 10) arg10 = (double)parser.Results[10];
                if (parser.Results.Count > 11) arg11 = (double)parser.Results[11];
                if (parser.Results.Count > 12) arg12 = (double)parser.Results[12];

            }
            else
            {
                result = -1;
            }

            int v_arg0 = 0;
            double v_arg1 = 0;
            double v_arg2 = 0;
            double v_arg3 = 0;
            double v_arg4 = 0;
            double v_arg5 = 0;
            double v_arg6 = 0;
            double v_arg7 = 0;
            double v_arg8 = 0;
            double v_arg9 = 0;
            double v_arg10 = 0;
            double v_arg11 = 0;
            double v_arg12 = 0;

            Util.ScanfWrapper.sscanf(buffer, format, ref v_arg0, ref v_arg1, ref v_arg2, ref v_arg3, ref v_arg4, ref v_arg5, ref v_arg6, ref v_arg7, ref v_arg8, ref v_arg9, ref v_arg10, ref v_arg11, ref v_arg12);

            Debug.Assert(arg0 == v_arg0, "warning wrapper");
            Debug.Assert(arg1 == v_arg1, "warning wrapper");
            Debug.Assert(arg2 == v_arg2, "warning wrapper");
            Debug.Assert(arg3 == v_arg3, "warning wrapper");
            Debug.Assert(arg4 == v_arg4, "warning wrapper");
            Debug.Assert(arg5 == v_arg5, "warning wrapper");
            Debug.Assert(arg6 == v_arg6, "warning wrapper");
            Debug.Assert(arg7 == v_arg7, "warning wrapper");
            Debug.Assert(arg8 == v_arg8, "warning wrapper");
            Debug.Assert(arg9 == v_arg9, "warning wrapper");
            Debug.Assert(arg10 == v_arg10, "warning wrapper");
            Debug.Assert(arg11 == v_arg11, "warning wrapper");
            Debug.Assert(arg12 == v_arg12, "warning wrapper");

            return result;
        }
    }
}
