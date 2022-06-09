using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public static class Image_Url
    {
        public const string urlImage = "/Image/";
    }    
    public class Product_View
    {
        public int id;
        public string name;
        public string imageName;
        public string description;
        public string category;
        public string trademark;
        public string infoproduct;
        public int quantityRemain;
        public Money Price;
        public Product_View()
        {
            id = 0;
            name = "";
            imageName = "";
            category = "";
            trademark = "";
            infoproduct = "";
            quantityRemain = 0;
            description = "";
            Price = new Money("VND");
        }
        public void Set_Product_View(int productid)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            Product dataSource = dataContext.Products.First(x => x.id == productid);
            this.id = productid;
            this.name = dataSource.name;
            this.quantityRemain = dataSource.quantityremain;
            this.imageName = Image_Url.urlImage + dataSource.images.First().name;
            this.Price = Money.Parse(dataSource.price);
        }
    }
    public class List_ProductView
    {
        public List<Category> list_categories;
        public static string sort = "";
        public static int ProductViewNumber = 6;
        public List<Product_View> data_views;
        public int AvalMaxPage;
        public int CurrentPage;
        public int Amount;
        public List_ProductView()
        {
            list_categories = new List<Category>();
            data_views = new List<Product_View>();
            Amount = 0;
            AvalMaxPage = 0;
            CurrentPage = 1;
        }
        public void Set_Product_View(int page, List<Product> datas)
        {
            Amount = datas.Count;
            int count = -1;
            AvalMaxPage = (datas.Count-1) / ProductViewNumber + 1;
            if (page <= AvalMaxPage) CurrentPage = page;
            else throw new Exception("Page Not Found");
            foreach (var data in datas)
            {
                count++;
                if (count < (page - 1) * ProductViewNumber) continue;
                if (count >= page * ProductViewNumber) break;
                Product_View data_view = new Product_View()
                {
                    id = data.id,
                    name = data.name,
                    Price = Money.Parse(data.price),
                    quantityRemain = data.quantityremain,
                    category = data.category.name,
                    trademark = data.trademark.name,
                    description = data.description,
                    infoproduct = data.infoproduct,
                };
                data_view.imageName = Image_Url.urlImage + data.images.First(x => x.productid == data.id).name;
                data_views.Add(data_view);
            }
        }
        public List<Product> SortBy(string option, List<Product> datas)
        {
            sort = option;
            switch (option)
            {
                case "Lowtohigh":
                    return datas.OrderBy(x => x.price).ToList();
                case "Hightolow":
                    return datas.OrderByDescending(x => x.price).ToList();
                case "Larger03":
                    return datas.Where(x => x.price > Money.Parse(1000000).Amount).OrderBy(x => x.price).ToList();
                case "Less03":
                    return datas.Where(x => x.price <= Money.Parse(1000000).Amount).OrderBy(x => x.price).ToList();
                case "Less02":
                    return datas.Where(x => x.price <= Money.Parse(100000).Amount).OrderBy(x => x.price).ToList();
                default:
                    break;
            }
            if (option != "")
            foreach (var i in this.list_categories)
            {
                if (option == i.id.ToString() || option == i.name) return datas.Where(x => x.categoryid == i.id).ToList();
            }
                
            return datas;
        }    
    }
    public class Product_View_Detail
    {
        public int id;
        public string trademark;
        public string category;
        public string desciption;
        public string productinfo;
        public int remainquantity;
        public string name;
        public string imageName;
        public Money Price;
        public Product_View_Detail()
        {
            id = 0;
            trademark = "";
            category = "";
            desciption = "";
            productinfo = "";
            remainquantity = 0;
            name = "";
            imageName = "";
            Price = new Money("VND");
        }
        public void Set_Product_Detail(int productid)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            Product dataSource = dataContext.Products.First(x => x.id == productid);
            this.id = productid;
            this.trademark = dataSource.trademark.name;
            this.category = dataSource.category.name;
            this.desciption = dataSource.description;
            this.productinfo = dataSource.infoproduct;
            this.remainquantity = dataSource.quantityremain;
            this.name = dataSource.name;
            this.imageName = Image_Url.urlImage+dataSource.images.First().name;
            this.Price = Money.Parse(dataSource.price);
        }    
    }
      
}