using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Controllers.Web
{
    public class ProductController : RouteController
    {
        public ProductController()
        {

        }
        // GET: Product
        public ActionResult Index(string name, int productid)
        {
            Product_View_Detail data = new Product_View_Detail();
            data.Set_Product_Detail(productid);
            return View(data);
        }
        [HttpPost]
        public ActionResult RedirectType(int quantity_input,int id, string type)
        {
            if (type == "Add to cart") return RedirectToAction("AddToCart", "Cart", new
            {
                quantity_input = quantity_input,
                productid = id,
            }) ; 
            else if (type == "Buy") return RedirectToAction("Buy", "Order", new
            {
                quantity_input = quantity_input,
                productid = id,
            });
            return new EmptyResult();
        }    
    }
}