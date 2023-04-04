using System;

namespace Util
{
    public class TimeManager
    {
        public static DateTime GetDate()
        {
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(Constants.TIMEZONE_PACIFIC);

            DateTime yourESTTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, tst);

            return yourESTTime;
        }

        public static string GetDateToString()
        {
            return GetDate().ToString(Constants.DATETIME_FORMAT);
        }
    }
}