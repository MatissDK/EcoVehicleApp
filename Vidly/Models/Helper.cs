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
        //TODO
         //need to get rid of millisecond 
        public static string ConvertStringToTimeDifference(string date)
        {
            var result = DateTimeOffset.Parse(date, CultureInfo.InvariantCulture);
            TimeSpan myTimeSpan = DateTime.Now - result;
            return Convert.ToString(myTimeSpan);
        }

    }
}