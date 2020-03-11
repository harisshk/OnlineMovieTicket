using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class AccountController : Controller
    {
        public AccountBL accountBL = new BL.AccountBL();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            if (login.Name != null && login.Password != null)
            {
                Account account = new Account
                {
                    Name = login.Name,
                    Password = login.Password
                };

                if (accountBL.Login(account))
                {
                    return RedirectToAction("Index", "Movie");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(SignupViewModel signup)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account
                {
                    Name = signup.Name,
                    Phone = signup.Phone,
                    Email = signup.Email,
                    Password = signup.Password,
                    Gender = signup.Gender
                };

                accountBL.Signup(account);
                
                ModelState.Clear();
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }
        public ActionResult Logged()
        {
            if (Session["UserId"]!= null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}