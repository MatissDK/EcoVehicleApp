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
		//
		// GET: /Home/Index
		public ActionResult Index()
		{
			var listOfVehicles = GetVehicles();
			return View(listOfVehicles);
		}


		public ActionResult GetJSON()
		{

			return Json(GetVehicles());
		}



		public List<Vehicle> GetVehicles()
		{
			Parser myParser = new Parser();
		    List<Vehicle> myList = myParser.ParseGetLastVehicleData();
			return myList;
		}
	}
}