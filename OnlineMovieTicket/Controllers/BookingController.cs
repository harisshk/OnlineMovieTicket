using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class BookingController : Controller
    {
        [CustomAuthorization(Roles = "Admin,User")]
        public ActionResult Book()
        {
            return View();
        }
    }
}