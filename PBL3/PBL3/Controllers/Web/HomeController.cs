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
        public ActionResult AllProduct(int id = 1)
        {
            List_ProductView list = new List_ProductView();
            try
            {
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
                throw;
            }
            list.list_categories = dataContext.Categories.ToList();
            list.Set_Product_View(id, list.SortBy(List_ProductView.sort, dataContext.Products.ToList()));
            return View(list);
        }
        public ActionResult AllProduct2(string sort)
        {
            List_ProductView list = new List_ProductView();
            try
            {
                list.list_categories = dataContext.Categories.ToList();
                list.Set_Product_View(1, list.SortBy(sort, dataContext.Products.ToList()));
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewData.Model = list;
            return View("AllProduct");
        }
    }
}