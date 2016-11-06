using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Vehicle
    {
        public int objectId { get; set; }
        public string address { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string objectName { get; set; }
        public double speed { get; set; }
        public string timeDifference { get; set; }
        public string timestamp { get; set; }
    }
}