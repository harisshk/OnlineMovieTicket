using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class MovieController : Controller
    {
        
        public MovieBL movieBL;

       
        public MovieController()
        {
            movieBL = new MovieBL();
        }

       
        public  ActionResult Index()
        {
            var movies = movieBL.Index();
            return View(movies);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Create(MovieModel movieModel)
        {

            if (ModelState.IsValid)
            {

                Movie movie = new Movie
                {
                    MovieId = movieModel.MovieId,
                    MovieName = movieModel.MovieName,
                    ShowTimeMorning = movieModel.ShowTimeMorning,
                    ShowTimeAfternoon = movieModel.ShowTimeAfternoon,
                    ShowTimeEvening = movieModel.ShowTimeEvening,
                    Price = movieModel.Price,
                    Duration = movieModel.Duration
                };

                movieBL.CreateMovie(movie);
                return RedirectToAction("Index","Movie");
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            movieBL.DeleteMovie(Id);
            
                return RedirectToAction("Index");
            
        }

        public ActionResult Edit(int id)
        {
            Movie movie = movieBL.Edit(id);

        return View(movie);
          
        }
        [HttpPost]
        
        public ActionResult EditMovie(MovieModel movieModel)
        {

            Movie movie = new Movie
            {
                MovieId = movieModel.MovieId,
                MovieName = movieModel.MovieName,
                ShowTimeMorning = movieModel.ShowTimeMorning,
                ShowTimeAfternoon = movieModel.ShowTimeAfternoon,
                ShowTimeEvening = movieModel.ShowTimeEvening,
                Duration = movieModel.Duration,
                Price = movieModel.Price
            };
            movieBL.EditMovie(movie);
            TempData["Message"] = "Updated";
            return RedirectToAction("Index");
        }

    }
}