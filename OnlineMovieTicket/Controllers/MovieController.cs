using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OnlineMovieTicket.BL;


namespace OnlineMovieTicket.Controllers
{
    public class MovieController : Controller
    {
        // GET: Index
        MovieBL movieBL;

        MovieRepository movieRepository;
       
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

                Movie movie = new Movie();
                movie.MovieId = movieModel.MovieId;
                movie.MovieName = movieModel.MovieName;
                movie.ShowTime = movieModel.ShowTime;
                movie.Price = movieModel.Price;

                using (DatabaseContext database = new DatabaseContext())
                {
                    database.MovieDetails.Add(movie);
                    database.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index","Movie");
            }
            return View();
        }
        public ActionResult Delete(int Id)
        {
            movieBL.DeleteBl(Id);
            
                return RedirectToAction("Index");
            
        }
        public ActionResult Edit(int id)
        {
            Movie movie = movieRepository.GetMovieId(id);
            return View(movie);
        }
        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            movieRepository.EditMovieDetails(movie);
            TempData["Message"] = "Movie Details Edited successfully!!";
            return RedirectToAction("Index");
        }
    }
}