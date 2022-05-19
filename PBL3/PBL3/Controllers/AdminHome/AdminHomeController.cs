using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Controllers.AdminHome
{
    public class AdminHomeController : RouteController
    {
        public static string Name = "AdminHome";
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}