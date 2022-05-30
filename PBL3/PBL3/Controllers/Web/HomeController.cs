using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
namespace PBL3.Controllers
{
    public class HomeController : RouteController
    {
        PBL3DataContext dataContext;
        public HomeController()
        {
            dataContext = new PBL3DataContext();
        }
        public ActionResult Index(int id = 1)
        {
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View(id, dataContext.Products.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            return View(list);
        }
        
    }
}