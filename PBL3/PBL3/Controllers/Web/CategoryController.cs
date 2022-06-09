using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;
namespace PBL3.Controllers.Web
{
    public class CategoryController : Controller
    {
        public CategoryController()
        {

        }    
        // GET: Category
        public ActionResult Index()
        {
            Category_View_List a = new Category_View_List();
            a.Set((new PBL3DataContext()).Categories.ToList());
            return View(a);
        }
    }
}