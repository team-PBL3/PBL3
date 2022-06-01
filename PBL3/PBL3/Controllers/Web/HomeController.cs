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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllProduct(int page = 1)
        {
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View(page, dataContext.Products.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            return View(list);
        }
<<<<<<< Updated upstream
        
=======
        public ActionResult AllProduct2(string sort, int page=1)
        {
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View(page, dataContext.Products.ToList());
                list.SortBy(sort);
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewData.Model = list;
            return View("AllProduct");
        }
>>>>>>> Stashed changes
    }
}