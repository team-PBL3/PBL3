using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
namespace PBL3.Controllers
{
    public class HomeController : RouteController
    {
        public HomeController()
        {
            //User a = new User { name = "QuocCuong", sex = "Nam", phone = 907333777, address = "75 Ly Trien", username = "quoccuong", email = "quoccuong@gmail.com", password = "eothuy", status = "INACTIVE", Id_Role=2 };
            //dataContext.Users.Add(a);
            //dataContext.SaveChanges();
            //DataContext = new pbl3Entities();
            //Pdata = DataContext.products.ToList();
            //Idata = DataContext.images.ToList();
        }
        public ActionResult Index(int id = 1)
        {
            //List<Product_Display> data_display = new List<Product_Display>();
            //for (int i = 0; i < 12; i++)
            //{
            //    product p = Pdata.ElementAt((id - 1) * 12 + i);
            //    string url = "";
            //    if (p.images.Count >= 1) url = p.images.ToList().ElementAt(0).name;
            //    else url = "Untitled.png";
            //    data_display.Add(new Product_Display(p.name, "~/Image/" + url, (float)p.price));
            //}
            //Product_Display data_display = null;
            //product p;
            //if (Pdata.Count > 0)
            //{
            //    p = Pdata.ElementAt(0);
            //    string url = "";
            //    if (p.images.Count >= 1) url = p.images.ToList().ElementAt(0).name;
            //    else url = "Untitled.png";
            //    data_display = new Product_Display(p.name, "~/Image/" + url, (float)p.price);
            //}
            //return View(data_display);
            return View(new PBL3DataContext().Users.ToList());
        }
        
    }
}