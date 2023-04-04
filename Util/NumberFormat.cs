using System.Globalization;

namespace Util
{
    public class NumberFormat
    {
        public static NumberFormatInfo NumberFormatDecimal(int numDecimals)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencyDecimalDigits = numDecimals;
            nfi.CurrencyDecimalSeparator = ".";
            nfi.NumberDecimalSeparator = ".";
            nfi.NumberDecimalDigits = numDecimals;
            return nfi;
        }

        public static NumberFormatInfo NumberFormatTipoCambio()
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencyDecimalDigits = 3;
            nfi.CurrencyDecimalSeparator = ".";
            nfi.NumberDecimalSeparator = ".";
            nfi.NumberDecimalDigits = 3;
            return nfi;
        }

        public static NumberFormatInfo NumberFormatInteger()
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencyDecimalDigits = 0;
            nfi.CurrencyDecimalSeparator = ".";
            nfi.NumberDecimalSeparator = ".";
            nfi.NumberDecimalDigits = 0;
            return nfi;
        }

        public static NumberFormatInfo NumberFormatBase(int DecimalDigits, string DecimalSeparator)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencyDecimalDigits = DecimalDigits;
            nfi.CurrencyDecimalSeparator = DecimalSeparator;
            nfi.NumberDecimalSeparator = DecimalSeparator;
            nfi.NumberDecimalDigits = DecimalDigits;
            return nfi;
        }
    }
}