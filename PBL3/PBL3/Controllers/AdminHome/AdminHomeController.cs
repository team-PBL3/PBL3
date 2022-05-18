using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Controllers.AdminController
{
    public class AdminHomeController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}