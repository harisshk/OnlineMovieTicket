using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        [CustomAuthorization(Roles = "Admin,User")]
        public ActionResult Book()
        {
            return View();
        }
    }
}