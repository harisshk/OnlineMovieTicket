using AutoMapper;
using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    [Authorize (Roles ="Admin")]
    public class MovieController : Controller
    {
        
        public MovieBL movieBL;

       
        public MovieController()
        {
            movieBL = new MovieBL();
        }

      [AllowAnonymous]
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
                var mapMovie = new MapperConfiguration(configExpression => { configExpression.CreateMap<MovieModel, Movie>(); });
                IMapper mapper = mapMovie.CreateMapper();
                var movie = mapper.Map<MovieModel, Movie>(movieModel);
                movie.CategoryId = 1;
                movieBL.CreateMovie(movie);
                return RedirectToAction("Index", "Movie");
            }
            //try
            //{

              
            //}
            //catch
            //{
            //    return View("Error");
            //}
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
            var mapMovie = new MapperConfiguration(configExpression => { configExpression.CreateMap<MovieModel, Movie>(); });
            IMapper mapper = mapMovie.CreateMapper();
            var movie = mapper.Map<MovieModel, Movie>(movieModel);
            movieBL.EditMovie(movie);
            TempData["Message"] = "Updated";
            return RedirectToAction("Index");
        }
        
    }
}