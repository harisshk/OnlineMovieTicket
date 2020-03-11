using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using OnlineMovieTicket.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class MovieController : Controller
    {
        
        public MovieBL movieBL;

        public MovieRepository movieRepository;
       
        public MovieController()
        {
            movieBL = new MovieBL();
            movieRepository = new MovieRepository();
        }
        public ActionResult Index()
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                List<Movie> movies = database.MovieDetails.ToList();
                return View(movies);
            }
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
                    ShowTime = movieModel.ShowTime,
                    Price = movieModel.Price
                };

                movieBL.CreateMovie(movie);
                ModelState.Clear();
                return RedirectToAction("Index","Movie");
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            movieBL.DeleteMovie(Id);
            
                return RedirectToAction("Index");
            
        } 
        //public ActionResult Edit()
        //{

        //}
    }
}