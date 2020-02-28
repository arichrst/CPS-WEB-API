using System;

namespace CPS
{
    public static class Formatter
    {
        public static string To_ddMMMyyyy(this DateTime date)
        {
            return date.ToString("dd MMM yyyy");
        }

        public static string To_ddMMMyyyymmhhss(this DateTime date)
        {
            return date.ToString("dd MMM yyyy mm:hh:ss");
        }

        public static string TimeAgo(this DateTime date, DateTime endDate)
        {
            var tmp = (int)(date-endDate).TotalSeconds;
            if(tmp/(3600*24) > 1)
                return (tmp/(3600*24)).ToString() + " hari yang lalu";
            else if(tmp/(3600*24) > 0 && tmp/(3600*24) <= 1)
                return "kemarin";
            else if(tmp/3600 > 0 && tmp/3600 < 24)
                return (tmp/3600).ToString() + " jam yang lalu";
            else if(tmp/60 > 0 && tmp/60 < 60)
                return (tmp/60).ToString() + " menit yang lalu";
            else
                return (tmp).ToString() + " detik yang lalu";
        }
    }
}