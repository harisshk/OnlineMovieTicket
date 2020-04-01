using AutoMapper;
using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    [CustomAuthorization(Roles = "Admin")]
    public class MovieController : Controller
    {

        public MovieBL movieBL;
        public CategoryBL categoryBL;
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
        public ActionResult CreateMovie() //Add Movie Page [GET]
        {
            IEnumerable<OnlineMovieTicket.Entity.Category> category = categoryBL.CategoryDetails();
            ViewBag.categories = new SelectList(category, "CategoryId", "CategoryName", "CategoryDescription");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        internal ActionResult CreateMovie(MovieModel movieModel) //Add Movie Page [POST]
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapMovie = new MapperConfiguration(configExpression => { configExpression.CreateMap<MovieModel, Movie>(); });
                    IMapper mapper = mapMovie.CreateMapper();
                    var movie = mapper.Map<MovieModel, Movie>(movieModel);
                    IEnumerable<OnlineMovieTicket.Entity.Category> categorys = categoryBL.CategoryDetails();
                    ViewBag.categories = new SelectList(categorys, "CategoryId", "CategoryName", "CategoryDescription");
                    movieBL.CreateMovie(movie);
                    return RedirectToAction("Index", "Movie");
                }

            }
            catch
            {
                return View("Error");
            }
            return View();
        }

        public ActionResult DeleteMovie(int Id) //Delete Movie
        {
            movieBL.DeleteMovie(Id);
            return RedirectToAction("Index");

        }
        public ActionResult EditMovie(int id) //Update Movie [GET]
        {
            Movie movie = movieBL.GetMovieId(id);
            IEnumerable<OnlineMovieTicket.Entity.Category> category = categoryBL.CategoryDetails();
            ViewBag.categories = new SelectList(category, "CategoryId", "CategoryName");
            return View(movie);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        internal ActionResult EditMovie(MovieModel movieModel) //Update Movie [POST]
        {
            var mapMovie = new MapperConfiguration(configExpression => { configExpression.CreateMap<MovieModel, Movie>(); });
            IMapper mapper = mapMovie.CreateMapper();
            var movie = mapper.Map<MovieModel, Movie>(movieModel);
            IEnumerable<OnlineMovieTicket.Entity.Category> category = categoryBL.CategoryDetails();
            ViewBag.categories = new SelectList(category, "CategoryId", "CategoryName");
            movieBL.UpdateMovie(movie);
            TempData["Message"] = "Updated";
            return RedirectToAction("Index");
        }

    }
}