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

        public ActionResult Login() //Login [GET]
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login) //Login [POST]
        {
            if (ModelState.IsValid)
            {
                //Auto mapper
                var mapAccount = new MapperConfiguration(configExpression => { configExpression.CreateMap<LoginViewModel, Account>(); });
                IMapper mapper = mapAccount.CreateMapper();
                var account = mapper.Map<LoginViewModel, Account>(login);

                Account accountDetails = accountBL.CheckUser(account); //Method call to check user.
                if (accountDetails != null)
                {
                    FormsAuthentication.SetAuthCookie(accountDetails.Name, false);
                    var authTicket = new FormsAuthenticationTicket(1, accountDetails.Name, DateTime.Now, DateTime.Now.AddMinutes(20), false, accountDetails.Role); //Authentication ticket is created to track session of user.
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie); //Session is added in cookies
                    return RedirectToAction("Index", "Movie");

                }
                else
                    TempData["LoginErrorMessage"] = "Invalid Username or Password";
            }


            return View();
        }
        public ActionResult Signup() //Signup [GET]
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(SignupViewModel signup) //Signup [POST]
        {
            if (ModelState.IsValid)
            {
                //Auto Mapper.
                var mapAccount = new MapperConfiguration(configExpression => { configExpression.CreateMap<SignupViewModel, Account>(); });
                IMapper mapper = mapAccount.CreateMapper();
                var account = mapper.Map<SignupViewModel, Account>(signup);
                accountBL.AddUser(account); //Method call to add user details
                return RedirectToAction("Login");
            }

            return View();
        }


        public ActionResult LogOff() //Log out
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut(); //Session is end for the user.
            return RedirectToAction("Index", "Movie");
        }
    }
}