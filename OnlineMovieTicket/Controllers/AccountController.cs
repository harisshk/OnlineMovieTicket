using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
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
                var mapAccount = new MapperConfiguration(cfg => { cfg.CreateMap<LoginViewModel, Account>(); });
                IMapper mapper = mapAccount.CreateMapper();
                var account = mapper.Map<LoginViewModel, Account>(login);
               
                Account accountDetails = accountBL.Login(account);
                if (accountDetails != null)
                {
                    FormsAuthentication.SetAuthCookie(accountDetails.Name, false);
                    var authTicket = new FormsAuthenticationTicket(1, accountDetails.Name, DateTime.Now, DateTime.Now.AddMinutes(20), false, accountDetails.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Movie");

                    //Session["UserId"] = accountDetails.UserId;
                    //return RedirectToAction("Index", "Movie");
                }
                else
                      TempData["LoginErrorMessage"] = "Invalid Username or Password";
              
                //}
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
                var mapAccount = new MapperConfiguration(cfg=>{ cfg.CreateMap<SignupViewModel, Account>(); });
                IMapper mapper = mapAccount.CreateMapper();
                var account = mapper.Map<SignupViewModel, Account>(signup);
                account.Role = "User";
                

                accountBL.Signup(account);
                
               // ModelState.Clear();
                return RedirectToAction("Login");
            }
            return View();
        }
       

        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Movie");
        }
    }
}