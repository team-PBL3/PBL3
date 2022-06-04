using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;

namespace PBL3.Controllers.AdminHome
{
    public class AdminHomeController : Controller
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
        public ActionResult ShowProduct(int page=1)
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
        [HttpGet]
        public ActionResult EditProduct(int productId=4)
        {
            Product product = new Product();
            product = dataContext.Products.First(x=>x.id==productId);
            ViewBag.images =  product.images.First().name;
            
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct2(Product product, string imagee)
        {

            dataContext.Edit(product, imagee);
            return RedirectToAction("ShowProduct");
        }
        public ActionResult DeleteProduct(int productId)
        {
            
            dataContext.Delete(productId);
            return RedirectToAction("ShowProduct");
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
        

    }
}