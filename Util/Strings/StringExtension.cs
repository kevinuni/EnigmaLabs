using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Strings
{
    public static class StringExtension
    {
        public static string Left(this string str, int count)
        {
            if (string.IsNullOrWhiteSpace(str) || count < 1)
                return str;

            return str.Substring(0, Math.Min(count, str.Length));
        }
        public static string Right(this string str, int count)
        {
            if (string.IsNullOrWhiteSpace(str) || count < 1)
            {
                return str;
            }


            return (str.Length <= count
                ? str
                : str.Substring(str.Length - count, count)
                );

        }
    }
}
