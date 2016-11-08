using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{

   
    public class HomeController : Controller
    {

       
        private static List<Vehicle> _myListOfLastData;
        private static List<Vehicle> _myRawData; 
        

        //display window with url input field 
        public ActionResult Index()
        {
            return View();
        }

        //shows data when API key is provided 
        [HttpPost]
        public ActionResult GetInfo(string url)
        {
            try
            {
                GetVehicles(url);
            }
            catch (Exception exception)
            {

                return Redirect("ArgumentError");
            }
            
            return View(_myListOfLastData);
        }

        //returns JSON data to GetInfo view 
        public ActionResult GetJson()
        {
            return Json(_myListOfLastData);
        }


        //shows window with date input data 
        public ActionResult DataInput()
        {    
            return View();
        }


        //need to provide date from user input 
        [HttpPost]
        public ActionResult ShowPolygonInfo(string date)
        {
            date = "2014-05-23";
            GetVehiclesRawData(date);
            return View(_myRawData);
        }


        public ActionResult JsonForPolygons()
        {
            return Json(_myRawData);
        }

        [HttpPost]
        public ActionResult ArgumentError()
        {
            return View();
        }


        /// <summary>
        ///  ////////////////////////
        /// </summary>
       

        //makes connection to getLatestData API
        public void GetVehicles(string url)
        {
            var myParser = new Parser();
            _myListOfLastData = myParser.ParseGetLastVehicleData(url);
        }


        //gets raw data about vehicles for provided date 
        public void GetVehiclesRawData(string date)
        {
            var objectIdArrayList = new ArrayList();
            foreach (var outData in _myListOfLastData)
            {
                objectIdArrayList.Add(outData.ObjectId);
            }

            var mParser = new Parser();
            _myRawData = mParser.ParseRawVehicleData(date, objectIdArrayList);
           
        }
    }
}