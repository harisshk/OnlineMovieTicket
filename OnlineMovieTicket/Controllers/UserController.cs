using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}