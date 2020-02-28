using System.Web.Mvc;
using OnlineMovieTicket.Entity;

namespace OnlineMovieTicket.Controllers
{
    public class AccountController : Controller
    {

        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountData accountData)
        {
            return View(accountData);
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(AccountData accountData)
        {
            return View(accountData);
        }
        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }
    }
}