using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
	public class HomeController : Controller
	{
		
        /// <summary>
        /// Index() is called when main View is loaded. 
        /// GetJson() is called from the view by Ajax call and provided information
        /// to the view in JSON format. 
        /// </summary>
		private new const string Url = "https://apps.oskando.ee/seeme/Api/Vehicles/getLastData?key=proovitoo1";

		public ActionResult Index()
		{
			var listOfVehicles = GetVehicles(Url);
			return View(listOfVehicles);
		}


		public ActionResult GetJson()
		{

			return Json(GetVehicles(Url));
		}



		public List<Vehicle> GetVehicles(string url)
		{
			Parser myParser = new Parser();
			List<Vehicle> myList = myParser.ParseGetLastVehicleData(url);
			return myList;
		}
	}
}