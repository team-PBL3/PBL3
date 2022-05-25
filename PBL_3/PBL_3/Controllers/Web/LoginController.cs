using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.isaccess = false;
            foreach (var i in datausers)
                if (i.email == email && i.password == password) //nếu mật khẩu và tài khoản nhập vào cùng tồn tại
                {
                    ViewBag.isaccess = true; //truyền dữ liệu thông báo đăng nhập thành công
                    Session.Add(RouteController.Account_Session, i);    //thêm tài khoản hiện hành đang hoạt động.
                    if (i.roleid == 1) return RedirectToAction("Index", AdminHome.AdminHomeController.Name);
                    //nếu là admin, đến trang chủ của admin
                    else if (i.roleid == 2) return RedirectToAction("Index", "Home");
                    //nếu là user, đến trang chủ của user
                    break;
                }
                else ViewBag.isaccess = false; //truyền dữ liệu thông báo đăng nhập thất bại
            return View();
        }
        [HttpPost]
        public ActionResult Sign_up(User model, string cfpass)
        {
            List<User> datausers = datacontext.Users.ToList();
            //SignUp_Errors error = new SignUp_Errors();
            bool success = true;
            if (model.name == null)
            {
                success = false;
                SignUp_Errors.Name = "please fill the field \" name \""; // nếu chưa nhập tên, hiện lỗi này.
            }
            else
            {
                SignUp_Errors.Name = ""; //ngược lại, xóa thông báo lỗi này.
            }

            if (model.sex == null)
            {
                success = false;
                SignUp_Errors.Sex = "please select a value in field \" sex \"";
            }
            else
            {
                SignUp_Errors.Sex = "";
            }

            if (model.address == null)
            {
                success = false;
                SignUp_Errors.Address = "please fill the field \" address \"";
            }
            else
            {
                SignUp_Errors.Address = "";
            }

            if (model.username == null)
            {
                success = false;
                SignUp_Errors.Username = "please fill the field \" username \"";
            }
            else
            {
                SignUp_Errors.Username = "";
                foreach (var data in datausers)
                {
                    if (data.username == model.username) //nếu tên tài khoản đã tồn tại, hiện lỗi này.
                    {
                        success = false;
                        SignUp_Errors.Username = $"user \"{model.username}\" have existed. please use another name";
                        break;
                    }
                }
            }
            if (model.email == null || !model.email.Contains("@"))
            {
                success = false;
                SignUp_Errors.Email = "invail email"; //nếu email không đúng, hiện lỗi này.
            }
            else
            {
                SignUp_Errors.Email = "";
                foreach (var data in datausers)
                {
                    if (data.email == model.email)
                    {
                        success = false;
                        SignUp_Errors.Email = $"this email have been used.";
                    }
                }
            }
            if (model.password == null) model.password = "";
            if (model.password.Length < 6) //nếu mật khẩu có ít hơn 6 ký tự, hiện lỗi này.
            {
                success = false;
                SignUp_Errors.Password = "length of password must larger than 6 characters.";
            }
            else
            {
                SignUp_Errors.Password = "";
            }
            if (model.password != cfpass) //nếu mậu khẩu và mật khẩu nhập lại không trùng nhau, hiện lỗi này.
            {
                success = false;
                SignUp_Errors.Cfpassword = "the confirm password don't match password.";
            }
            else
            {
                SignUp_Errors.Cfpassword = "";
            }

            if (success == false) SignUp_Errors.result = "sign up fail!"; //nếu còn lỗi, thông báo thêm đăng ký thất bại.
            else
            {       //nếu đăng ký thành công, thêm tài khoản vào database.
                User user = new User();
                user.name = model.name;
                user.sex = model.sex;
                user.phone = model.phone;
                user.address = model.address;
                user.username = model.username;
                user.email = model.email;
                user.status = "INACTIVE";
                user.password = model.password;
                user.roleid = 2;
                datacontext.Adding(user);
                return View("Sign_in");
            }

            return View();
        }
    }
}