﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Controllers.Member
{
    public class MemberController : RouteController
    {
        public static string Name = "Member";
        // GET: UserHome
        public ActionResult Index()
        {
            return View();
        }
    }
}