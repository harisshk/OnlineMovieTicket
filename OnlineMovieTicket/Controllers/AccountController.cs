using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class AccountController : Controller
    {


        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult Signup()
        {
            return View("Signup");
        }
        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }
    }
}