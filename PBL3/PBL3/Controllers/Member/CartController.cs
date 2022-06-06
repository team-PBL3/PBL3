using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
namespace PBL3.Controllers.Member
{
    public class CartController : RouteController
    {
        public static string Name = "Cart";
        PBL3DataContext dataContext;
        Cart_View cartView;
        // GET: Cart
        public CartController()
        {
            dataContext = new PBL3DataContext();
            cartView = null;
        }    
        public ActionResult Index(int newproductid=0)
        {
            if (cartView == null)
            {
                User account = (User)Session[Account_Session];
                cartView = new Cart_View(dataContext.Carts.First(x => x.user.id == account.id));
            }

            if (newproductid == 0)
            {
                ViewBag.NewCD = null;
            }
            else
            {
                ViewBag.NewCD = cartView.lViews.dataViews.First(x => x.product_view.id == newproductid);
            }

            return View(cartView);
        }
        public ActionResult AddToCart(int quantity_input, int productid)
        {
            if (cartView == null)
            {
                User account = (User)Session[Account_Session];
                cartView = new Cart_View(dataContext.Carts.First(x => x.user.id == account.id));
            }
            try
            {
                cartView.AddToCart(productid);
            }
            catch (Exception e)
            {
                if (e.Message!="HaveExsit") throw;
            }
            return RedirectToAction("Index", new { newproductid = productid });
        }    
        public ActionResult Delete(int id)
        {
            dataContext.DeleteCD(id);
            return RedirectToAction("Index");
        }    
        public ActionResult DeleteAll()
        {
            dataContext.DeleteCDAll();
            return RedirectToAction("Index");
        }    
    }
}