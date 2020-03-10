using OnlineMovieTicket.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                List<Movie> movies = database.MovieDetails.ToList();
                return View(movies);
            }
        }
    }
}