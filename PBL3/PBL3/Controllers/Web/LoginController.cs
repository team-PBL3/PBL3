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
        pbl3Entities dataContext; //Biến dữ liệu từ database.
        public LoginController()
        {
            
             dataContext= new pbl3Entities();
        }    
        // GET: Login
        public ActionResult Sign_up()
        {
            SignUp_Errors a = new SignUp_Errors();
            ViewBag.SignUp_Check = new SignUp_Errors(); //truyền biến dữ liệu qua view thông qua viewbag
            return View();
        }
        public ActionResult Sign_in()
        {
            return View();
        }   
        [HttpPost]
        public ActionResult Sign_in(string email, string password)
        {
            List<user> dataUsers = dataContext.users.ToList();  //Lấy dữ liệu bảng User.
            ViewBag.isAccess = false;
            foreach (var i in dataUsers)
                if (i.email == email && i.password == password) //Nếu mật khẩu và tài khoản nhập vào cùng tồn tại
                {
                    ViewBag.isAccess = true; //truyền dữ liệu thông báo đăng nhập thành công
                    Session.Add(RouteController.Account_Session, i);    //Thêm tài khoản hiện hành đang hoạt động.
                    if (i.Idrole == 1) return RedirectToAction("Index", AdminHome.AdminHomeController.Name);
                    //Nếu là admin, đến trang chủ của admin
                    else if (i.Idrole == 2) return RedirectToAction("Index", "Home");
                    //Nếu là user, đến trang chủ của user
                    break;
                }
                else ViewBag.isAccess = false; //truyền dữ liệu thông báo đăng nhập thất bại
            return View();
        }
        [HttpPost]
        public ActionResult Sign_up(user model, string cfpass)
        {
            List<user> dataUsers = dataContext.users.ToList();
            SignUp_Errors error = new SignUp_Errors();
            bool success = true;
            if (model.name == null)
            {
                success = false;
                error.Name = "Please fill the field \" Name \""; // Nếu chưa nhập tên, hiện lỗi này.
            }
            else
            {
                error.Name = ""; //ngược lại, xóa thông báo lỗi này.
            }

            if (model.sex == null)
            {
                success = false;
                error.Sex = "Please select a value in field \" Sex \"";
            }
            else
            {
                error.Sex = "";
            }

            if (model.address == null)
            {
                success = false;
                error.Address = "Please fill the field \" Address \"";
            }
            else
            {
                error.Address = "";
            }

            if (model.username == null)
            {
                success = false;
                error.Username = "Please fill the field \" Username \"";
            }
            else
            {
                error.Username = "";
                foreach (var data in dataUsers)
                {
                    if (data.username==model.username) //Nếu tên tài khoản đã tồn tại, hiện lỗi này.
                    {
                        success = false;
                        error.Username = $"User \"{model.username}\" have existed. Please use another name";
                        break;
                    }    
                }    
            }
            if (model.email == null || !model.email.Contains("@"))
            {
                success = false;
                error.Email = "Invail email"; //Nếu email không đúng, hiện lỗi này.
            }
            else
            {
                error.Email = "";
                foreach(var data in  dataUsers)
                {
                    if (data.email == model.email)
                    {
                        success = false;
                        error.Email = $"This email have been used.";
                    }    
                }    
            }
            if (model.password == null) model.password = "";
            if (model.password.Length < 6) //Nếu mật khẩu có ít hơn 6 ký tự, hiện lỗi này.
            {
                success = false;
                error.Password = "Length of password must larger than 6 characters.";
            }
            else
            {
                error.Password = "";
            }
            if (model.password!=cfpass) //Nếu mậu khẩu và mật khẩu nhập lại không trùng nhau, hiện lỗi này.
            {
                success = false;
                error.Cfpassword = "The confirm password don't match password.";
            }
            else
            {
                error.Cfpassword = "";
            }

            if (success == false) error.result = "Sign up fail!"; //Nếu còn lỗi, thông báo thêm đăng ký thất bại.
            else
            {       //Nếu đăng ký thành công, thêm tài khoản vào database.
                dataContext.CreateNewUser(model.name, model.sex, model.phone, model.address, model.username, model.email, 
                    model.password, "INACTIVE", 2);
                return View("Sign_in");
            }    
            ViewBag.SignUp_Check = error;

            return View();
        }
    }
}