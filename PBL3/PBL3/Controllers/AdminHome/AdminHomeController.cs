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
        public ActionResult Index(int id=1)
        {
            List<Product> products = dataContext.Products.ToList();

            ViewBag.Total = dataContext.TotalPrice();


            List_CustomerView list2 = new List_CustomerView();
            try
            {
                list2.Set_Customer_View(id, dataContext.Users.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewBag.ShowCustomer = list2;
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View2(id, dataContext.Products.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewBag.ProductTotal = list;

            return View(products);


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
            }
            catch(Exception)
            {
                throw;
            }
            return View();
        }
        public ActionResult ShowProduct(int id=1)
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
        public ActionResult ShowCustomer(int id = 1)
        {
            List_CustomerView list2 = new List_CustomerView();
            try
            {
                list2.Set_Customer_View(id, dataContext.Users.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }

            return View(list2);
        }
        [HttpGet]
        public ActionResult EditProduct(int productId)
        {
            Product product = new Product();
            product = dataContext.Products.First(x=>x.id==productId);
            ViewBag.images =  product.images.First().name;
            
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct2(Product product, string imagee)
        {

            dataContext.Edit(product, imagee, (User)Session["Account_Session"]);
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
        public ActionResult Statistics()
        {
            
            List<Product> products = dataContext.Products.ToList();
            
            ViewBag.Total = dataContext.TotalPrice();
            return View(products);

        }
        public ActionResult Member(int id = 1)
        {

            List_CustomerView list2 = new List_CustomerView();
            try
            {
                list2.Set_Customer_View(id, dataContext.Users.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View2(id, dataContext.Products.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewBag.ProductTotal = list;

            return View(list2);
        }
        public ActionResult Category(int id = 1)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            List_CustomerView list2 = new List_CustomerView();
            try
            {
                list2.Set_Customer_View(id, dataContext.Users.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewBag.ShowCustomer = list2;
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View2(id, dataContext.Products.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewBag.ProductTotal = list;
            return View(dataContext);
        }
        public ActionResult Product(int id = 1)
        {
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View2(id, dataContext.Products.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }


            List_CustomerView list2 = new List_CustomerView();
            try
            {
                list2.Set_Customer_View(id, dataContext.Users.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewBag.ShowCustomer = list2;
            return View(list);

        }
        public ActionResult TableDetail()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove(RouteController.Account_Session);
            return RedirectToAction("Index", "Home");
        }
            
    }
}