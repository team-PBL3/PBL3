using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
namespace PBL3.Controllers.Web
{
    public class LoginController : RouteController
    {
        PBL3DataContext datacontext; //biến dữ liệu từ database.
        public LoginController()
        {
            datacontext = new PBL3DataContext();
        }
        // get: login
        public ActionResult Sign_up()
        {
            //SignUp_Errors a = new signup_errors();
            //viewbag.signup_check = new signup_errors(); //truyền biến dữ liệu qua view thông qua viewbag
            return View();
        }
        public ActionResult Sign_in()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sign_in(string email, string password)
        {
            List<User> datausers = datacontext.Users.ToList();  //lấy dữ liệu bảng user.
            ViewBag.SignIn = "";
            try
            {
                User user = Account_Sign_in.Check_Signing_In(datausers, email, password);
                Session.Add(RouteController.Account_Session, user);    //thêm tài khoản hiện hành đang hoạt động.
                if (user.roleid == 1) return RedirectToAction("Index", AdminHome.AdminHomeController.Name);
                //nếu là admin, đến trang chủ của admin
                else if (user.roleid == 2) return RedirectToAction("Index", "Home");
                //nếu là user, đến trang chủ của user
            }
            catch (Exception e)
            {
                ViewBag.SignIn = e.Message;
            }
            return View();
        }
        

        [HttpPost]
        public ActionResult Sign_Up(Account_Sign_Up model)
        {
            if (ModelState.IsValid)
            {
                User NewUser = new User() {
                    name = model.name, sex = model.sex, phone = model.phone,
                    address = model.address, username = model.username, email = model.email,
                    password = model.password, status = "INACTIVE", roleid = 2};
                datacontext.Adding(NewUser);
                
                return RedirectToAction("Sign_in", "Login");
                //SignUp_Errors error = new SignUp_Errors();
            }
            return View();
        }

        public ActionResult Check_Existing_UserName(string username)
        {
            return Json(!datacontext.Users.Any(x => x.username == username), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Check_Existing_Email(Account_Sign_Up Account)
        {
            return Json(!datacontext.Users.Any(x => x.email == Account.email), JsonRequestBehavior.AllowGet);
        }    
        public ActionResult Is_Matched_Passwork(string cfpassword, string password)
        {
            if (cfpassword != password) return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}