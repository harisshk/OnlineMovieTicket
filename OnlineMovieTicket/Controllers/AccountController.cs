using System.Linq;
using System.Web.Mvc;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;

namespace OnlineMovieTicket.Controllers
{
    public class AccountController : Controller
    {
            
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (login.Name != null && login.Password != null)
            {

                using (Entity.DatabaseContext database = new DatabaseContext())
                {
                    var usr = database.AccountDetail.SingleOrDefault(model => model.Name == login.Name && model.Password == login.Password);
                    if (usr != null )
                    {
                        Session["UserId"] = usr.UserId.ToString();
                        Session["UserName"] = usr.Name.ToString();
                        return RedirectToAction("Logged");
                    }
                    else
                    {
                        TempData["Msg"] = "Invalid credentials";
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SignupViewModel signup)
        {
                      

            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.Name = signup.Name;
                account.Phone = signup.Phone;
                account.Email = signup.Email;
                account.Password = signup.Password;
                account.Gender = signup.Gender;
                        
                using (DatabaseContext database = new DatabaseContext())
                {
                    database.AccountDetail.Add(account);
                    database.SaveChanges();
                }
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