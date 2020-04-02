using AutoMapper;
using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{

    public class MovieController : Controller
    {
         readonly MovieBL movieBL;
         readonly CategoryBL categoryBL;
        public MovieController() //Constructor
        {
            movieBL = new MovieBL();
            categoryBL = new CategoryBL();
        }
        [AllowAnonymous]
        public ActionResult Index() //HomePage
        {
            var movies = movieBL.GetAllMovies();
            return View(movies);
        }
        [CustomAuthorization(Roles = "Admin")]
        public ActionResult CreateMovie() //Add Movie Page [GET]
        {
            IEnumerable<OnlineMovieTicket.Entity.Category> category = categoryBL.CategoryDetails();//Get category into movie add view.
            ViewBag.categories = new SelectList(category, "CategoryId", "CategoryName", "CategoryDescription");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovie(MovieModel movieModel) //Add Movie Page [POST]
        {
            if (ModelState.IsValid)
            {
                //Auto Mapper
                var mapMovie = new MapperConfiguration(configExpression => { configExpression.CreateMap<MovieModel, Movie>(); });
                IMapper mapper = mapMovie.CreateMapper();
                var movie = mapper.Map<MovieModel, Movie>(movieModel);
                IEnumerable<OnlineMovieTicket.Entity.Category> categorys = categoryBL.CategoryDetails();//Get category into movie add view.
                ViewBag.categories = new SelectList(categorys, "CategoryId", "CategoryName", "CategoryDescription");
                movieBL.CreateMovie(movie);
                return RedirectToAction("Index", "Movie");
            }
            return View();
        }

        [CustomAuthorization(Roles = "Admin")]
        public ActionResult DeleteMovie(int Id) //Delete Movie
        {
            movieBL.DeleteMovie(Id); //Funnction call to delete movie.
            return RedirectToAction("Index");
        }
        [CustomAuthorization(Roles = "Admin")]
        public ActionResult EditMovie(int id) //Update Movie [GET]
        {
            Movie movie = movieBL.GetMovieId(id);
            IEnumerable<OnlineMovieTicket.Entity.Category> category = categoryBL.CategoryDetails(); //Get category into movie edit view.
            ViewBag.categories = new SelectList(category, "CategoryId", "CategoryName");
            return View(movie);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMovie(MovieModel movieModel) //Update Movie [POST]
        {
            //Auto Mapper.
            var mapMovie = new MapperConfiguration(configExpression => { configExpression.CreateMap<MovieModel, Movie>(); });
            IMapper mapper = mapMovie.CreateMapper();
            var movie = mapper.Map<MovieModel, Movie>(movieModel);
            IEnumerable<OnlineMovieTicket.Entity.Category> category = categoryBL.CategoryDetails(); //Get category into movie edit movie details.
            ViewBag.categories = new SelectList(category, "CategoryId", "CategoryName");
            movieBL.UpdateMovie(movie);
            TempData["Message"] = "Updated";
            return RedirectToAction("Index");
        }
    }
}