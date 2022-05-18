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
    public class LoginController : Controller
    {
        Pbl3DataContext dataContext;
        public LoginController()
        {
            dataContext = new Pbl3DataContext();
        }    
        // GET: Login
        public ActionResult Sign_up()
        {
            //Pbl3DataContext dataContext = new Pbl3DataContext();
            //List<User> dataUsers = dataContext.Users.ToList();
            SignUp_Errors a = new SignUp_Errors();
            ViewBag.SignUp_Check = new SignUp_Errors();
            return View();
        }
        public ActionResult Sign_in()
        {
            return View();
        }   
        [HttpPost]
        public ActionResult Sign_in(string email, string password)
        {
            //Pbl3DataContext dataContext = new Pbl3DataContext();
            List<User> dataUsers = dataContext.Users.ToList();
            ViewBag.isAccess = false;
            foreach (var i in dataUsers)
                if (i.Email == email && i.Password == password)
                {
                    ViewBag.isAccess = true;
                    Session.Add(RedirController.Account_Session, i);
                    if (i.Idrole == 1) return RedirectToAction("Index", "AdminHome");
                    else if (i.Idrole == 2) return RedirectToAction("Index", "UserHome");
                    break;

                }
                else ViewBag.isAccess = false;
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
                error.Name = "Please fill the field \" Name \"";
            }
            else
            {
                error.Name = "";
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
                    if (data.Username==model.Username)
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
                error.Email = "Invail email";
            }
            else
            {
                error.Email = "";
            }
            if (model.Password == null) model.Password = "";
            if (model.Password.Length < 6)
            {
                success = false;
                error.Password = "Length of password must larger than 6 characters.";
            }
            else
            {
                error.Password = "";
            }
            if (model.Password!=cfpass)
            {
                success = false;
                error.Cfpassword = "The confirm password don't match password.";
            }
            else
            {
                error.Cfpassword = "";
            }

            if (success == false) error.result = "Sign up fail!";
            else
            {
                dataContext.CreateNewUser(dataUsers.Count+1, model.Name, model.Sex, model.Phone, model.Address,
                    model.Username, model.Email, model.Password, "INACTIVE", 2);
                return View("Sign_in");
            }    
            ViewBag.SignUp_Check = error;

            return View();
        }
    }
    
}