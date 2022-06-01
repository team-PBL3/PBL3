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
        public int quantityremain;
        public Money Price;
        public Product_View()
        {
            id = 0;
            name = "";
            imageName = "";
            category = "";
            trademark = "";
            infoproduct = "";
            quantityremain = 0;
            description = "";
            Price = new Money("VND");
        }
    }
    public class List_ProductView
    {
        public static int ProductViewNumber = 6;
        public List<Product_View> data_views;
        public int AvalMaxPage;
        public int CurrentPage;
        public List_ProductView()
        {
            data_views = new List<Product_View>();
            AvalMaxPage = 0;
            CurrentPage = 1;
        }
        public void Set_Product_View(int id, List<Product> datas)
        {
            int count = -1;
            AvalMaxPage = (datas.Count-1) / ProductViewNumber + 1;
            if (id <= AvalMaxPage) CurrentPage = id;
            else throw new Exception("Page Not Found");
            foreach (var data in datas)
            {
                count++;
                if (count < (id - 1) * ProductViewNumber) continue;
                if (count >= id * ProductViewNumber) break;
                Product_View data_view = new Product_View()
                {
                    id = data.id,
                    name = data.name,
                    Price = Money.Parse(data.price),
                    trademark = data.trademark.name,
                    category = data.category.name,
                    description = data.description,
                    infoproduct = data.infoproduct,
                    quantityremain = data.quantityremain

                };
                data_view.imageName = Image_Url.urlImage + data.images.First(x => x.productid == data.id).name;
                data_views.Add(data_view);
            }
        }
        
        public void SortBy(string option)
        {
            switch (option)
            {
                case "Lowtohigh":
                    this.data_views = this.data_views.OrderBy(x => x.Price.Amount).ToList();
                    break;
                case "Hightolow":
                    this.data_views = this.data_views.OrderByDescending(x => x.Price.Amount).ToList();
                    break;
                case "Larger03":
                    this.data_views = this.data_views.Where(x => x.Price.Amount > Money.Parse(1000000).Amount).OrderBy(x => x.Price.Amount).ToList();
                    break;
                case "Less03":
                    this.data_views = this.data_views.Where(x => x.Price.Amount <= Money.Parse(1000000).Amount).OrderBy(x => x.Price.Amount).ToList();
                    break;
                case "Less02":
                    this.data_views = this.data_views.Where(x => x.Price.Amount <= Money.Parse(100000).Amount).OrderBy(x => x.Price.Amount).ToList();
                    break;
                default:
                    break;
            }
        }    
    }
    public class Product_View_Detail
    {
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
    public class Money
    {
        private string Unit;
        public double Amount;
        public Money()
        {
            Amount = 0.0;
            Unit = "VND";
        }
        public Money(string unit)
        {
            Amount = 0.0;
            Unit = unit;
        }
        public override string ToString()
        {
            return Amount + " " + Unit;
        }
        public static Money Parse(double amount)
        {
            return new Money() { Amount = amount};
        }
    }    
}