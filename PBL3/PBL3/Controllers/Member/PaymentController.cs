using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
namespace PBL3.Controllers.Web
{
    public class PaymentController : RouteController
    {
        // GET: Payment
        [HttpGet]
        public ActionResult Index(int orderid)
        {
            Payment_View data = new Payment_View(orderid);
            return View(data);
        }
        [HttpGet]
        public ActionResult NewPay()
        {
            User user = (User)Session[Account_Session];
            Payment_View data = new Payment_View(user);

            return View(data);
        }   
    }
}