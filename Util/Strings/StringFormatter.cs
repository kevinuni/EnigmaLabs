using System;
using System.Globalization;

namespace Enigma.Util.Strings
{
    public class StringFormatter
    {
        /// <summary>
        /// Devuelve la fecha en formato como: Jueves 09 Julio de 2015
        /// </summary>
        /// <param name="texttofilter"></param>
        /// <returns></returns>
        public static string FormatoFecha(DateTime date, bool mostrasNombreDia)
        {
            DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
            string nombreMes = formatoFecha.GetMonthName(date.Month);

            CultureInfo ci = new CultureInfo(Constants.CULTURE_ES_PE);
            string nombreDia = mostrasNombreDia ? ci.DateTimeFormat.GetDayName(date.DayOfWeek) : string.Empty;

            return string.Format("{0} {1} de {2} de {3}", nombreDia, date.Day.ToString("D2"), nombreMes, date.Year).Trim();
        }
    }
}