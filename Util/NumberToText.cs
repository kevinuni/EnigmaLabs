using System;

namespace Util
{
    public class NumberToText
    {
        public static string Convert(double value)
        {
            int numval = System.Convert.ToInt32(value);
            string str;
            double num = value;
            switch (numval)
            {
                case 0:
                    return "CERO";

                case 1:
                    return "UN";

                case 2:
                    return "DOS";

                case 3:
                    return "TRES";

                case 4:
                    return "CUATRO";

                case 5:
                    return "CINCO";

                case 6:
                    return "SEIS";

                case 7:
                    return "SIETE";

                case 8:
                    return "OCHO";

                case 9:
                    return "NUEVE";

                case 10:
                    return "DIEZ";

                case 11:
                    return "ONCE";

                case 12:
                    return "DOCE";

                case 13:
                    return "TRECE";

                case 14:
                    return "CATORCE";

                case 15:
                    return "QUINCE";
            }
            if (num < 20.0)
            {
                return ("DIECI" + Convert(value - 10.0));
            }
            if (num == 20.0)
            {
                return "VEINTE";
            }
            if (num < 30.0)
            {
                return ("VEINTI" + Convert(value - 20.0));
            }
            if (num == 30.0)
            {
                return "TREINTA";
            }
            if (num == 40.0)
            {
                return "CUARENTA";
            }
            if (num == 50.0)
            {
                return "CINCUENTA";
            }
            if (num == 60.0)
            {
                return "SESENTA";
            }
            if (num == 70.0)
            {
                return "SETENTA";
            }
            if (num == 80.0)
            {
                return "OCHENTA";
            }
            if (num == 90.0)
            {
                return "NOVENTA";
            }
            if (num < 100.0)
            {
                return (Convert((double)(System.Convert.ToInt32((long)(((long)Math.Round(value, MidpointRounding.AwayFromZero)) / 10L)) * 10L)) + " Y " + Convert(value % 10.0));
            }
            if (num == 100.0)
            {
                return "CIEN";
            }
            if (num < 200.0)
            {
                return ("CIENTO " + Convert(value - 100.0));
            }
            if ((((num == 200.0) || (num == 300.0)) || (num == 400.0)) || ((num == 600.0) || (num == 800.0)))
            {
                return (Convert((double)System.Convert.ToInt32((long)(((long)Math.Round(value, MidpointRounding.AwayFromZero)) / 100L))) + "CIENTOS");
            }
            switch (numval)
            {
                case 500:
                    return "QUINIENTOS";

                case 700:
                    return "SETECIENTOS";

                case 900:
                    return "NOVECIENTOS";
            }
            if (num < 1000)
            {
                return (Convert((double)(System.Convert.ToInt32((long)(((long)Math.Round(value, MidpointRounding.AwayFromZero)) / 100L)) * 100L)) + " " + Convert(value % 100.0));
            }
            if (num == 1000)
            {
                return "MIL";
            }
            if (num < 2000)
            {
                return ("MIL " + Convert(value % 1000.0));
            }
            if (num < 1000000)
            {
                str = Convert((double)System.Convert.ToInt32((long)(((long)Math.Round(value, MidpointRounding.AwayFromZero)) / 0x3e8L))) + " MIL";
                if ((value % 1000.0) != 0.0)
                {
                    str = str + " " + Convert(value % 1000.0);
                }
                return str;
            }
            if (num == 1000000)
            {
                return "UN MILLON";
            }
            if (num < 2000000)
            {
                return ("UN MILLON " + Convert(value % 1000000.0));
            }
            if (num < 1000000000000)
            {
                str = Convert((double)(System.Convert.ToInt64(value) / 1000000)) + " MILLONES ";
                if ((value - ((System.Convert.ToInt64(value) / 1000000) * 1000000.0)) != 0.0)
                {
                    str = str + " " + Convert(value - ((System.Convert.ToInt64(value) / 1000000) * 1000000.0));
                }
                return str;
            }
            if (num == 1000000000000)
            {
                return "UN BILLON";
            }
            if (num < 2000000000000)
            {
                return ("UN BILLON " + Convert(value - (System.Convert.ToInt32((double)(value / 1000000000000)) * 1000000000000)));
            }
            str = Convert(System.Convert.ToInt32((double)(value / 1000000000000))) + " BILLONES";
            if ((value - (System.Convert.ToInt32((double)(value / 1000000000000)) * 1000000000000)) != 0.0)
            {
                str = str + " " + Convert(value - (System.Convert.ToInt32((double)(value / 1000000000000)) * 1000000000000));
            }
            return str;
        }

        public static string ConvertWithDecimal(double value)
        {
            double parteentera = Math.Truncate(System.Convert.ToDouble(value));
            int decplaces = value.ToString("N2").Length;
            string partedecimal = value.ToString("N2").Substring(decplaces - 2, 2);
            return (Convert(parteentera) + " y " + partedecimal.ToString() + "/100");
        }
    }
}