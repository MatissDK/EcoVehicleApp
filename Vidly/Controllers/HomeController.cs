﻿using System;
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
        

        //display window with Url input field 
        public ActionResult Index()
        {
            return View();
        }

        //shows data when API key is provided 
        [HttpPost]
        public ActionResult GetInfo(string url)
        {

            if (url != "proovitoo1")
            {
                return RedirectToAction("ArgumentError", "Home");
            }
            else
            {
                url = "https://apps.oskando.ee/seeme/Api/Vehicles/getLastData?key=proovitoo1";

                try
                {
                    GetVehicles(url);
                }
                catch (Exception exception)
                {

                    return RedirectToAction("ArgumentError", "Home");
                }
            }

            return View(_myListOfLastData);
        }


        //returns JSON data to GetInfo view 
        public ActionResult GetJson()
        {
            return Json(_myListOfLastData);
        }


        public ActionResult ShowPolygonInfo(string date)
        {
            try
            {
                GetVehiclesRawData(date);
                return View(_myRawData);
            }
            catch (Exception exception)
            {

                return RedirectToAction("ArgumentError", "Home");
            }
            
        }

        public ActionResult Demo()
        {
            return View();
        }


        public ActionResult JsonForPolygons()
        {
            return Json(_myRawData);
        }

       
        public ActionResult ArgumentError()
        {
            
            return View();
        }

      
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