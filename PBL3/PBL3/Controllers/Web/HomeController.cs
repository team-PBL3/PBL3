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
            
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllProduct(int id = 1)
        {
            dataContext = new PBL3DataContext();
            List_ProductView list = new List_ProductView();
            try
            {
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
                throw;
            }
            ViewBag.Sort = list.sort;
            list.list_categories = dataContext.Categories.ToList();
            list.Set_Product_View(dataContext.Products.ToList());
            return View(list);
        }
        public ActionResult AllProduct2(List<string> sort)
        {
            dataContext = new PBL3DataContext();
            List_ProductView list = new List_ProductView();
            try
            {
                list.list_categories = dataContext.Categories.ToList();
                list.Set_Product_View(list.SortBy(sort, dataContext.Products.ToList()));
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewBag.Sort = sort;
            ViewData.Model = list;
            return View("AllProduct");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove(RouteController.Account_Session);
            return RedirectToAction("Index");
        }
    }
}