using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using System.Web.Mvc;
using System.Web.Security;
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
            if (ModelState.IsValid)
            {
                Account account = new Account
                {
                    Name = login.Name,
                    Password = login.Password
                };
                Account accountDetails = accountBL.Login(account);
                if (accountDetails != null)
                {

                    Session["UserId"] = accountDetails.UserId;
                    return RedirectToAction("Index", "Movie");
                }
                //else
                //{
                   TempData["LoginErrorMessage"] = "Invalid Username or Password";
                //    return RedirectToAction("Login");
                //}
            }
           // TempData["LoginErrorMessage"] = "Invalid Username or Password";
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
                
               // ModelState.Clear();
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }
        
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}