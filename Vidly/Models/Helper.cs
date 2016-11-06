using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Vidly.Utils
{
    public class Helper
    {
        
         /// <summary>
         ///  get rid of millisecond 
         /// </summary>
         /// <param name="date"></param>
         /// <returns></returns>

        public static string ConvertStringToTimeDifference(string date)
        {
            var result = DateTimeOffset.Parse(date, CultureInfo.InvariantCulture);
            TimeSpan myTimeSpan = DateTime.Now - result;
            String timeWithMilliseconds = Convert.ToString(myTimeSpan);
            String normalTime = timeWithMilliseconds.Remove(timeWithMilliseconds.Length - 8);
            return Convert.ToString(normalTime);
        }


        public static string TrimOffTimeZone(string date)
        {
            return date.Remove(date.Length - 5);

        }

    }
}