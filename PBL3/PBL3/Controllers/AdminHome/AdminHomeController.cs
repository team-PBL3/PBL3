using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;

namespace PBL3.Controllers.AdminHome
{
    public class AdminHomeController : RouteController
    {
        public static string Name = "AdminHome";
        PBL3DataContext datacontext;
        // GET: Admin
        public AdminHomeController()
        {
            datacontext = new PBL3DataContext();
        }
        public ActionResult Index()
        {

            return View();
        }    
    }
}