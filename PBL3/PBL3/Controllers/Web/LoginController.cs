using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devart.Data.Linq;
using Pbl3Context;
using PBL3.Models;
namespace PBL3.Controllers.Web
{
    public class LoginController : RouteController
    {
        Pbl3DataContext dataContext; //Biến dữ liệu từ database.
        public LoginController()
        {
            dataContext = new Pbl3DataContext();
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
            List<User> dataUsers = dataContext.Users.ToList();  //Lấy dữ liệu bảng User.
            ViewBag.isAccess = false;
            foreach (var i in dataUsers)
                if (i.Email == email && i.Password == password) //Nếu mật khẩu và tài khoản nhập vào cùng tồn tại
                {
                    ViewBag.isAccess = true; //truyền dữ liệu thông báo đăng nhập thành công
                    Session.Add(RouteController.Account_Session, i);    //Thêm tài khoản hiện hành đang hoạt động.
                    if (i.Idrole == 1) return RedirectToAction("Index", AdminHome.AdminHomeController.Name);
                    //Nếu là admin, đến trang chủ của admin
                    else if (i.Idrole == 2) return RedirectToAction("Index", Member.MemberController.Name);
                    //Nếu là user, đến trang chủ của user
                    break;
                }
                else ViewBag.isAccess = false; //truyền dữ liệu thông báo đăng nhập thất bại
            return View();
        }
        [HttpPost]
        public ActionResult Sign_up(User model, string cfpass)
        {
            List<User> dataUsers = dataContext.Users.ToList();
            SignUp_Errors error = new SignUp_Errors();
            bool success = true;
            if (model.Name == null)
            {
                success = false;
                error.Name = "Please fill the field \" Name \""; // Nếu chưa nhập tên, hiện lỗi này.
            }
            else
            {
                error.Name = ""; //ngược lại, xóa thông báo lỗi này.
            }

            if (model.Sex == null)
            {
                success = false;
                error.Sex = "Please select a value in field \" Sex \"";
            }
            else
            {
                error.Sex = "";
            }

            if (model.Address == null)
            {
                success = false;
                error.Address = "Please fill the field \" Address \"";
            }
            else
            {
                error.Address = "";
            }

            if (model.Username == null)
            {
                success = false;
                error.Username = "Please fill the field \" Username \"";
            }
            else
            {
                error.Username = "";
                foreach (var data in dataUsers)
                {
                    if (data.Username==model.Username) //Nếu tên tài khoản đã tồn tại, hiện lỗi này.
                    {
                        success = false;
                        error.Username = $"User \"{model.Username}\" have existed. Please use another name";
                        break;
                    }    
                }    
            }
            if (model.Email == null || !model.Email.Contains("@"))
            {
                success = false;
                error.Email = "Invail email"; //Nếu email không đúng, hiện lỗi này.
            }
            else
            {
                error.Email = "";
                foreach(var data in  dataUsers)
                {
                    if (data.Email == model.Email)
                    {
                        success = false;
                        error.Email = $"This email have been used.";
                    }    
                }    
            }
            if (model.Password == null) model.Password = "";
            if (model.Password.Length < 6) //Nếu mật khẩu có ít hơn 6 ký tự, hiện lỗi này.
            {
                success = false;
                error.Password = "Length of password must larger than 6 characters.";
            }
            else
            {
                error.Password = "";
            }
            if (model.Password!=cfpass) //Nếu mậu khẩu và mật khẩu nhập lại không trùng nhau, hiện lỗi này.
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
                dataContext.CreateNewUser(model.Name, model.Sex, model.Phone, model.Address,
                    model.Username, model.Email, model.Password, "INACTIVE", 2);
                return View("Sign_in");
            }    
            ViewBag.SignUp_Check = error;

            return View();
        }
    }
}