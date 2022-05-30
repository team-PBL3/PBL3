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

        }    
        // GET: Product
        public ActionResult Index(string name, int productid)
        {
            Product_View_Detail data = new Product_View_Detail();
            data.Set_Product_Detail(productid);
            return View(data);
        }
    }
}