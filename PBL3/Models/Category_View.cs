using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Partofbody
    {
        public string Name;
        public List<Category_View> categorylist;
        public Partofbody()
        {
            Name = "";
            categorylist = new List<Category_View>();
        }    
        public void Set(string name, List<Category> list)
        {
            Name = name;
            foreach(var item in list)
            {
                categorylist.Add(new Category_View(item));
            }    
        }    
    }
    public class Category_View
    {
        public string name;
        public List<Product_Display> productlist;
        public Category_View()
        {
            name = "";
            productlist = new List<Product_Display>();
        }    
        public Category_View(Category datasource)
        {
            productlist = new List<Product_Display>();
            name = datasource.name;
            foreach(var item in datasource.Products)
            {
                productlist.Add(new Product_Display(item));
                if (productlist.Count == 3) break;
            }    
        }
    }    
    public class Category_View_List
    {
        public List<Partofbody> list;

        public Category_View_List()
        { 
            list = new List<Partofbody>();
        }    
        public void Set(List<Category> listsource)
        {
            var i = listsource.GroupBy(x => x.partofbody).ToList();
            foreach(var t in i)
            {
                var a = new Partofbody();
                a.Set(t.Key, t.ToList());
                list.Add(a);
            }    
        }    
    }
}