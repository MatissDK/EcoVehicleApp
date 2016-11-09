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

        /// <summary>
        /// Index() is called when main View is loaded. 
        /// GetJsonData() provides information to the view, makes 3 separate API calls.
        /// Could be refactored for better usability and performance 
        /// </summary>

        private const string Vehicle1041 = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=1041&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";
        private const string Vehicle1949 = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=1949&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";
        private const string Vehicle969 = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=969&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";

        //need to add objectId and date  + check if valid Url 

        //public ActionResult Index()
        //{
        //    return View(GetVehicles(Vehicle1041));
        //}



        ////Test controller (mvcaction4 + tab) 
        //public ActionResult Action()
        //{
        //    //var viewModel = new Vehicle();
        //    return View();
        //}

        ////Test controller (mvcaction4 + tab) 
        //[HttpPost]
        //public ActionResult Create(Vehicle vehicle)
        //{
        //    return RedirectToAction("ShowData", "Vehicles", vehicle);
        //}

        ////testing 
        //public ActionResult ShowData(Vehicle vehicle)
        //{

        //    return Content(vehicle.address);
        //}


        //public ActionResult GetJsonData()
        //{
        //    List<Vehicle> myList1041 = GetVehicles(Vehicle1041);
        //    List<Vehicle> myList1949 = GetVehicles(Vehicle1949);
        //    List<Vehicle> myList969 = GetVehicles(Vehicle969);

        //    myList1041.AddRange(myList1949);
        //    myList1041.AddRange(myList969);
        //    return Json(myList1041);
        //}


        //public List<Vehicle> GetVehicles(string Url)
        //{
        //    Parser mParser = new Parser();
        //    List<Vehicle> myList = mParser.ParseRawVehicleData(Url);
        //    return myList;
        //}
    }
}