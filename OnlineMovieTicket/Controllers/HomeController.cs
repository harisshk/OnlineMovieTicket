using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public MovieBL movieBL;
        public HomeController()
        {
            movieBL = new MovieBL();
        }

        public ActionResult Index()
        {
            var movies = movieBL.Index();
            return View(movies);
        }
    }
}