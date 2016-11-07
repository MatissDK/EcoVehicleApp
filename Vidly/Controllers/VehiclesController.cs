using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class VehiclesController : Controller
    {

        private const string Vehicle1041 = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=1041&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";
        private const string Vehicle1949 = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=1949&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";
        private const string Vehicle969 = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=969&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";


        //
        // GET: /Vehicles/
        public ActionResult Index()
        {
            return View(GetVehicles(Vehicle1041));
        }

        public ActionResult GetJsonData1041()
        {
            List<Vehicle> myList1041 = GetVehicles(Vehicle1041);
            List<Vehicle> myList1949 = GetVehicles(Vehicle1949);
            List<Vehicle> myList969 = GetVehicles(Vehicle969);

            myList1041.AddRange(myList1949);
            myList1041.AddRange(myList969);
            return Json(myList1041);
        }


        public List<Vehicle> GetVehicles(string url)
        {
            Parser mParser = new Parser();
            List<Vehicle> myList = mParser.ParseRawVehicleData(url);
            return myList;
        }
    }
}