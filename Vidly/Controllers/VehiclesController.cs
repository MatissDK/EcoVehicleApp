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
		//const string VEHICLE_1041 = @"c:\users\matiss\desktop\1041.xml";
		//const string VEHICLE_1949 = @"c:\users\matiss\desktop\1949.xml";
		//const string VEHICLE_969 = @"c:\users\matiss\desktop\969.xml";

		const string VEHICLE_1041 = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=1041&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";
		const string VEHICLE_1949 = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=1949&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";
		const string VEHICLE_969 = "https://apps.oskando.ee/seeme/Api/Vehicles/getRawData?objectId=969&begTimestamp=2013-02-01&endTimestamp=2013-02-02&key=proovitoo1";




		//
		// GET: /Vehicles/
		public ActionResult Index()
		{
			return View(GetVehicles(VEHICLE_1041));
		}

		public ActionResult GetJsonData1041()
		{
			List<Vehicle> myList1041 = GetVehicles(VEHICLE_1041);
			List<Vehicle> myList1949 = GetVehicles(VEHICLE_1949);
			List<Vehicle> myList969 = GetVehicles(VEHICLE_969);

			foreach (var outData in myList1949)
			{
				myList1041.Add(outData);
			}

			foreach (var outData in myList969)
			{
				myList1041.Add(outData);
			}

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