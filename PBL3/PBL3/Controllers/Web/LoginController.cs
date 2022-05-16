using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devart.Data.Linq;
using Pbl3Context;
namespace PBL3.Controllers.Web
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Sign_up()
        {
            //Pbl3DataContext dataContext = new Pbl3DataContext();
            //List<User> dataUsers = dataContext.Users.ToList();
            return View();
        }
        public ActionResult Sign_in(string email, string password)
        {
            Pbl3DataContext dataContext = new Pbl3DataContext();
            List<User> dataUsers = dataContext.Users.ToList();
            ViewBag.isAccess = false;
            foreach (var i in dataUsers)
                if (i.Email == email && i.Password == password) ViewBag.isAccess = true;
                else ViewBag.isAccess = false;
            return View();
        }
        [HttpPost]
        public ActionResult Sign_up(User user)
        {
            return View();
        }
    }
}