using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Controllers.Web
{
    public class ProductController : Controller
    {
        public ProductController()
        {

<<<<<<< Updated upstream
        }    
=======
        }
>>>>>>> Stashed changes
        // GET: Product
        public ActionResult Index(string name, int productid)
        {
            Product_View_Detail data = new Product_View_Detail();
            data.Set_Product_Detail(productid);
            return View(data);
        }
<<<<<<< Updated upstream
=======
        [HttpGet]
        public ActionResult RedirectType(int quantity_input,string product, string type)
        {
            if (type == "Add to cart") return RedirectToAction("AddToCart", "Cart", new
            {
                quantity_input = quantity_input,
                product = product
            });
            else if (type == "Buy") return RedirectToAction("Buy", "Payment", new
            {
                quantity_input = quantity_input,
                product = product
            });
            return new EmptyResult();
        }    
>>>>>>> Stashed changes
    }
}