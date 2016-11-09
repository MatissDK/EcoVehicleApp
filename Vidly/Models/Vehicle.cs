using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Vehicle
    {


        [Required]
        [StringLength(255,MinimumLength = 1)]
        [Display(Name = "Please enter your API key to check latest data")]
        public string Url { get; set; }

        public string address { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string objectName { get; set; }

        public double speed { get; set; }
        public string timeDifference { get; set; }

        [Display(Name = "Please enter your date")]
        [StringLength(100,MinimumLength = 1)]
        public string timestamp { get; set; }


        public int ObjectId { get; set; }

        //test data 
        public bool type { get; set; }
    }
}