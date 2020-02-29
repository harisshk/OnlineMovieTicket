﻿using OnlineMovieTicket.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class MovieController : Controller
    {
        // GET: Index

        MovieRepository movieRepository;
        public MovieController()
        {
            movieRepository = new MovieRepository();
        }
        public ActionResult Index()
        {
            IEnumerable<Movie> bus = movieRepository.GetMovieDetails();
            return View(bus);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection formCollection) ////////// Form Collection
        {
            try
            {
                Movie movie = new Movie();
                
                if (TryUpdateModel(movie))    
                {
                movieRepository.AddMovie(movie);
                TempData["Message"] = "Movie detail added successfully!!!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {

            movieRepository.DeleteMovie(id);
            TempData["Message"] = "Movie Detail deleted successfully";
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