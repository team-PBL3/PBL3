using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
using PBL3.Controllers.AdminHome;
using System.Web.Routing;
namespace PBL3.Controllers
{
    public class RouteController : Controller   //Class định hướng route
    {
        // GET: Route
        public static string Account_Session = "Account_Session";
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User account = (User)Session[Account_Session];
            //Cập nhật Session từ database.
            if (account != null) Session[Account_Session] = (new PBL3DataContext()).Users.First(x => x.id == account.id);
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            if (account == null)
            {
                if (controller == Member.MemberController.Name || controller == AdminHomeController.Name
                    || controller == Member.CartController.Name || controller == "Order" || controller == "Payment")
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new { controller = "Login", action = "Sign_in" }));
            }
            else
            {
                if (account.Role.id == 1 && controller != AdminHomeController.Name)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                        (new { controller = AdminHome.AdminHomeController.Name, action = "Index" }));
                }
                else if (account.Role.id == 2 && (controller == AdminHomeController.Name || controller == "Login"))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                        (new { controller = Member.MemberController.Name, action = "Index" }));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}