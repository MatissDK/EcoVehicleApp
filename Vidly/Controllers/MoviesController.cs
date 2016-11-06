using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		//
		// GET: /Movies/Random
		//public ActionResult Random()
		//{
		//    var movie = new Movie() { Name = "Shrek!"};
		//    var customers = new List<Customer>
		//    {
		//        new Customer{ Name = "Otto"},
		//        new Customer{Name = "Kalns"}

		//    };

		//    var viewModel = new RandomMovieViewModel
		//    {
		//        Customer = customers,
		//        Movie = movie
		//    };

		//    return View(viewModel);
		//}

		public ViewResult Index()
		{
		    var movies = GetMovies();
			
		    return View(movies);

		}

		public List<Movie> GetMovies()
		{
			return new List<Movie>
			{
				new Movie{Name = "Shrek", Id = 1},
				new Movie{Name = "Wall-e", Id = 2},
			};

		}


		//public ActionResult Edit(int id)
		//{
		//    return Content("id:" + id);
		//}

		//public ActionResult Index(int? pageIndex, string sortBy)
		//{
		//    if (!pageIndex.HasValue)
		//    {
		//        pageIndex = 1;
		//    }
		//    if (String.IsNullOrWhiteSpace(sortBy))
		//    {
		//        sortBy = "Name";
		//    }
		//    return Content(pageIndex + sortBy);
		//}
	}
}