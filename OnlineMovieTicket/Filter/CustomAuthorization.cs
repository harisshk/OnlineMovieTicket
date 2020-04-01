using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    public class CustomAuthorization:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(AuthorizeCore(filterContext.HttpContext))
            {
            base.OnAuthorization(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}   