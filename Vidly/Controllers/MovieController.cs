using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };
            List<Customer> customers = new List<Customer>()
            {
                new Customer(){ Name = "Customer 1"},
                new Customer(){ Name = "Customer 2"},
                new Customer(){ Name = "Customer 3"},
                new Customer(){ Name = "Customer 4"},
                new Customer(){ Name = "Customer 5"}
            };
            //return View(movie);
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            RandomMovieViewModel viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            return Content(Id.ToString());
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            //return Content(string.Format("page = {0}, sort by = {1}", pageIndex, sortBy));

            return View(_context.Movie.Include(m => m.Genre));

        }

        public ActionResult Details(int id)
        {
            //return Content(string.Format("page = {0}, sort by = {1}", pageIndex, sortBy));

            return View(_context.Movie.Include(m => m.Genre).SingleOrDefault(m => m.Id == id));

        }

        [Route("movie/release/{year:regex(\\d{4}):range(1900, 2019)}/{month:regex(1[0-2]|[1-9]|0[1-9]):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("y:{0} m:{1}", year, month));
        }
    }
}