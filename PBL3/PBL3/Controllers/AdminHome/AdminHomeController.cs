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
        public ActionResult Index(int id = 1)
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
                list.Set_Product_View2(dataContext.Products.ToList());
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
            return RedirectToAction("Category");
        }
        public ActionResult addTradeMark()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addTradeMark(string nametm)
        {

            try
            {
                TradeMark trademark = new TradeMark();
                trademark.name = nametm;
                if (dataContext.Adding(trademark) > 0) ViewBag.Message = $"Adding trademark {nametm} successfully.";
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return RedirectToAction("Category");
        }
        public ActionResult addProduct()
        {
            ViewBag.Data = dataContext.Products.ToList();
            return View("");
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
            catch (Exception)
            {
                return View("Error");

            }
            return RedirectToAction("TableDetail");

        }
        public ActionResult ShowProduct(int id = 1)
        {
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View(dataContext.Products.ToList());
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
            product = dataContext.Products.First(x => x.id == productId);
            ViewBag.images = product.images.First().name;

            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct2(Product product, string imagee)
        {

            dataContext.Edit(product, imagee, (User)Session["Account_Session"]);
            return RedirectToAction("TableDetail");
        }
        public ActionResult DeleteProduct(int productId)
        {

            dataContext.Delete(productId);
            return RedirectToAction("TableDetail");
        }
        public ActionResult AllProduct(int page = 1)
        {
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View(dataContext.Products.ToList());
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
                list.Set_Product_View2(dataContext.Products.ToList());
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
                list.Set_Product_View2(dataContext.Products.ToList());
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
                list.Set_Product_View2(dataContext.Products.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewBag.ShowProduct = list;
            return View();
        }
        public ActionResult TableDetail()
        {
            List_ProductView list = new List_ProductView();
            try
            {
                list.Set_Product_View2(dataContext.Products.ToList());
            }
            catch (Exception e)
            {
                if (e.Message == "Page Not Found") return View("Error");
            }
            ViewBag.ListProduct = list;

            Product product = new Product();
            product = dataContext.Products.First();
            ViewBag.images = product.images.First().name;

            return View(product);
        }
        public ActionResult Logout()
        {
            Session.Remove(RouteController.Account_Session);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangePassWord(string pwcurrent, string pwmuondoi, string pwxacnhan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = (User)Session[Account_Session];
                    (new PBL3DataContext()).UpdatePW(user, pwmuondoi);

                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return View("Index");
        }
        public ActionResult Is_Matched_Passwork(string cfpassword, string pwmuondoi)
        {
            if (cfpassword != pwmuondoi) return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CurrentPw(string pwcurrent)
        {
            User user = (User)Session[Account_Session];
            if (pwcurrent != user.password) return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ktraCategory(string name, string partofbody)
        {
            PBL3DataContext pbl3 = new PBL3DataContext();
            if (pbl3.Categories.Where(i => i.name == name && i.partofbody == partofbody).Count() != 0)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ktratrademark(string nametm)
        {
            PBL3DataContext pbl3 = new PBL3DataContext();
            if (pbl3.TradeMarks.Where(i => i.name == nametm).Count() != 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Order()
        {
            List<Orderr> orderrs = dataContext.Orderrs.ToList();
            return View(orderrs);
        }
        public ActionResult EditOrder(Orderr orderr)
        {
            dataContext.Edit2(orderr);
            return RedirectToAction("Order");
        }
    }
}