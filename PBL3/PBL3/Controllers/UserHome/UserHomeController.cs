using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Controllers.UserHome
{
    public class UserHomeController : RouteController
    {
        public static string Name = "UserHome";
        // GET: UserHome
        public ActionResult Index()
        {
            return View();
        }
    }
}