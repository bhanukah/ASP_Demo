using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };
            //return View(movie);
            return View(movie);
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

            return Content(string.Format("page = {0}, sort by = {1}", pageIndex, sortBy));
        }

        [Route("movie/release/{year:regex(\\d{4}):range(1900, 2019)}/{month:regex(1[0-2]|[1-9]|0[1-9]):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("y:{0} m:{1}", year, month));
        }
    }
}