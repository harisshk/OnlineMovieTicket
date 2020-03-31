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
        internal ActionResult Login(LoginViewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapAccount = new MapperConfiguration(configExpression => { configExpression.CreateMap<LoginViewModel, Account>(); });
                    IMapper mapper = mapAccount.CreateMapper();
                    var account = mapper.Map<LoginViewModel, Account>(login);

                    Account accountDetails = accountBL.CheckUser(account);
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
            }
            catch
            {
                return View("Error");
            }
            
          
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        internal ActionResult Signup(SignupViewModel signup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapAccount = new MapperConfiguration(configExpression => { configExpression.CreateMap<SignupViewModel, Account>(); });
                    IMapper mapper = mapAccount.CreateMapper();
                    var account = mapper.Map<SignupViewModel, Account>(signup);
                    account.Role = "User";


                    accountBL.AddUser(account);

                    // ModelState.Clear();
                    return RedirectToAction("Login");
                }
            }
            catch
            {
                return View("Error");
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