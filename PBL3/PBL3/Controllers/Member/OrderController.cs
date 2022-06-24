using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
namespace PBL3.Controllers.Member
{
    public class OrderController : RouteController
    {
        public OrderController()
        {
            
        }
        // GET: Order
        public ActionResult Index()
        {
            User user = (User)Session[Account_Session];
            ListOrderView list = new ListOrderView((new PBL3DataContext()).Orderrs.Where(x => x.userid == user.id).ToList());
            return View(list);
        }
        public ActionResult Detail(int Orderid)
        {
            User user = (User)Session[Account_Session];
            return View((new PBL3DataContext()).Orderrs.First(y=>y.id==Orderid));
        }    
        public ActionResult Buy(int quantity_input, int productid)
        {
            Product_View_Detail a = new Product_View_Detail();
            a.Set_Product_Detail(productid);
            ViewBag.quantity = quantity_input;
            ViewBag.PVD = a;
            return View();
        }
        public ActionResult Buy2(List<int> quantity_input, List<int> CDid)
        {
            try
            {
                if (CDid==null)
                {
                    return RedirectToAction("Index","Cart");
                }    
                List_CD_View la = new List_CD_View(((User)Session[Account_Session]).carts.First());
                la.Set_CD_View(CDid, quantity_input);
                ViewBag.list = la;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult OrderProduct(List<double> price, List<int> quantity, List<int> productid, List<int> CDid, Person toPerson)
        {
            try
            {
                List<Orderdetail> LOD = new List<Orderdetail>();
                for(int i=0; i<price.Count; i++)
                {
                    LOD.Add(new Orderdetail() { price = price.ElementAt(i), quantity = quantity.ElementAt(i), Time = DateTime.Now, productid = productid.ElementAt(i)});
                }    
                PBL3DataContext dataContext = new PBL3DataContext();
                dataContext.CreateOrder(LOD, (User)Session[Account_Session], CDid, toPerson);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("NewPay","Payment");
        }
        public ActionResult DeleteOrder(int Orderid)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            dataContext.DeleteOrder(Orderid);
            return RedirectToAction("Index");
        }    
        public JsonResult Check_Number(Person person)
        {
            foreach(var i in person.phone)
            {
                if (i < '0' || i > '9') return Json(false, JsonRequestBehavior.AllowGet);
            }    
            return Json(true, JsonRequestBehavior.AllowGet);
        }    
    }
}