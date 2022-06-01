using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Controllers
{
    public class PageNotFoundController : Controller
    {
        // GET: ErrorPage
        public ActionResult Index()
        {
            return View("Error");
        }
    }
}