using System;

namespace Enigma.Util
{
    public class Periodo
    {
        public static string AddPeriodo(string PeriodoActual, int NumMeses, int NumYears)
        {
            int mes = int.Parse(PeriodoActual.Substring(4, 2));
            int year = int.Parse(PeriodoActual.Substring(0, 4));

            DateTime date = new DateTime(year, mes, 1);
            return date.AddMonths(NumMeses).AddYears(NumYears).ToString("yyyyMM");
        }

        /// <summary>
        /// Número de periodos entre ambos periodos(se cuentan los extremos)
        /// </summary>
        /// <param name="periodoinicial">Periodo inicial</param>
        /// <param name="periodofinal">Periodo final</param>
        /// <returns></returns>
        public static int NroPeriodos(string periodoinicial, string periodofinal)
        {
            int anoperiodoinicial = int.Parse(periodoinicial.Substring(0, 4));
            int mesperiodoinicial = int.Parse(periodoinicial.Substring(4, 2));

            int añoperiodofinal = int.Parse(periodofinal.Substring(0, 4));
            int mesperiodofinal = int.Parse(periodofinal.Substring(4, 2));

            int meses = (añoperiodofinal - anoperiodoinicial) * 12 + (mesperiodofinal - mesperiodoinicial) + 1;
            return meses;
        }

        /// <summary>
        /// Diferencia en número de dias entre dos fechas
        /// </summary>
        /// <param name="ini">Fecha inicial</param>
        /// <param name="fin">Fecha final</param>
        /// <returns></returns>
        public static int Datediff(DateTime ini, DateTime fin)
        {
            TimeSpan diferencia = fin.Date.Subtract(ini.Date);

            return diferencia.Days;
        }
    }
}