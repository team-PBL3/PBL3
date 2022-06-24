using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(user);
        }
    }
}