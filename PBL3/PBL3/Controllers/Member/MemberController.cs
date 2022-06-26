using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
namespace PBL3.Controllers.Member
{
    public class MemberController : RouteController
    {
        public static string Name = "Member";
        public MemberController()
        {

        }
        public ActionResult Index()
        {
            User user = (User)Session[Account_Session];
            ViewBag.Cof = user.orders.Where(i => i.status == "Đã xác nhận").Count();
            ViewBag.Ship = user.orders.Where(i => i.status == "Đang giao").Count();
            ViewBag.Com = user.orders.Where(i => i.status == "Đã hoàn thành").Count();
            ViewBag.Cart = user.carts.First();
            return View(user);
        }
        [HttpPost]
        public ActionResult ChangInfo(User user)
        {
            (new PBL3DataContext()).Edit(user);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ChangPwd(User user)
        {
            (new PBL3DataContext()).Edit(user);
            return RedirectToAction("Index");
        }
        public ActionResult CheckPwd(string oldpwd)
        {
            User user = (User)Session[RouteController.Account_Session];
            if (oldpwd != user.password) return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Is_Matched_Password(string cfpassword, string password)
        {
            if (cfpassword != password) return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Check_Val_Pwd(string password)
        {
            bool i = Regex.IsMatch(password, @".*([A-Z])+.*") && Regex.IsMatch(password, @".*(\d)+.*") && Regex.IsMatch(password, @".*(^[\w\s])+.*");
            if (!i) return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}