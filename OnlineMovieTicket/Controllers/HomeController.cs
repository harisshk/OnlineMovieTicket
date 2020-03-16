using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }

    }
}