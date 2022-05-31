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
        PBL3DataContext dataContext;
        // GET: Admin
        public AdminHomeController()
        {
            dataContext = new PBL3DataContext();
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult addCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addCategory(Category category)
        {
            try
            {
                if (dataContext.Adding(category) > 0) ViewBag.Message = $"Adding trademark {category.name} successfully.";
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
        public ActionResult addTradeMark()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addTradeMark(TradeMark trademark)
        {
            try
            {
                if (dataContext.Adding(trademark)>0) ViewBag.Message = $"Adding trademark {trademark.name} successfully.";
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
        public ActionResult addProduct()
        {
            ViewBag.Data = dataContext.Products.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult addProduct(Product product, string imagee)
        {
            try
            {
                product.quantityremain = product.quantityInit;
                product.images.Add(new Image() { name = imagee, productid = product.id });
                dataContext.Adding(product);

                return new RedirectResult($"https://localhost:44325/AdminHome/ShowProduct?productId={product.id}&image={imagee}");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
        public ActionResult ShowProduct(int productId, string image)
        {
            ViewData.Model = dataContext.Products.FirstOrDefault(x => x.id == productId);
            ViewBag.Image = image;
            return View();
        }

        public ActionResult editProduct()
        {
            dataContext.Products.ToList().ElementAt(0).quantityInit += 10;
            dataContext.SaveChanges();
            return View("Error");
        }
        



    }
}