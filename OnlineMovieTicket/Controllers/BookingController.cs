﻿using OnlineMovieTicket.Filter.ExceptionFilterInMVC.Models;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    [CustomAuthorization(Roles = "Admin,User")]
    public class BookingController : Controller
    {
        public ActionResult Book() //Booking page
        {
            return View();
        }
    }
}