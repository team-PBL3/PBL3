using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pbl3Context;
using System.Web.Routing;
namespace PBL3.Controllers
{
    public class RedirController : Controller
    {
        public static string Account_Session = "Account_Session";
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User account = (User)Session[RedirController.Account_Session];
            if (account == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new { controller = "Login", action = "Sign_in" }));
            }
            else if (account.Idrole == 1)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new { controller = "UserHome", action = "Index" }));
            }
            else if (account.Idrole == 2)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new { controller = "AdminHome", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}