using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                password = Encrypt.ToEncrypt( model.password), status = "INACTIVE", roleid = 2};
                datacontext.Adding(NewUser);
                
                return RedirectToAction("Sign_in", "Login");                
            }
            return View();
        }
        public ActionResult ForgetPwd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPwd(User user)
        {
            User a = datacontext.CheckExistingEmail(user);
            if (a != null)
            {
                return RedirectToAction("NewPassword", new { i = a.id});
            }
            else ViewBag.Error = "Không tìm thấy mật khẩu chứa thông tin này";
            return View();
        }
        public ActionResult NewPassword(int i)
        {
            ViewBag.id = i;
            return View();
        }
        [HttpPost]
        public ActionResult NewPassword(int id, string password)
        {
            User user = datacontext.Users.First(i=>i.id==id);
            user.password = password;
            Session.Add(RouteController.Account_Session, user);
            datacontext.Edit(user);
            return RedirectToAction("Index","Home");
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
        public ActionResult Check_Val_Pwd(string password)
        {
            bool i = Regex.IsMatch(password, @".*([A-Z])+.*") && Regex.IsMatch(password, @".*(\d)+.*") && Regex.IsMatch(password, @".*([^\w\s])+.*");
            if (!i) return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}