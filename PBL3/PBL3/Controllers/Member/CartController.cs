using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
namespace PBL3.Controllers.Member
{
    public class CartController : Controller
    {
        PBL3DataContext dataContext;
        // GET: Cart
        public CartController()
        {
            dataContext = new PBL3DataContext();
        }    
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(int quantity_input, string product)
        {

            return View();
        }    
    }
}