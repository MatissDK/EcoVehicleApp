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
         ///  
         /// ConvertStringToTimeDifference() takes string paramter and removes milliseconds 
         /// TrimOffTimeZone() is used to provide data time in string format from Model to the View without time zone attachment 
         ///  
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

        public static string UrlCreator(string date, string objectId)
        {
            //2014-05-23
            string url =
                "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=" + objectId +
                "&begTimestamp=" + date + "&endTimestamp=2014-05-24&key=proovitoo1";

            return url;

        }

    }
}