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
        public string trademark;
        public string category;
        public string desciption;
        public string productinfo;
        public int remainquantity;
        public string name;
        public string imageName;
        public Money Price;
        public Product_View()
        {
            trademark = "";
            desciption = "";
            productinfo = "";
            remainquantity = 0;
            name = "";
            imageName = "";
            Price = new Money("VND");
        }
    }
    public class List_ProductView
    {
        public static int ProductViewNumber = 2;
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
            AvalMaxPage = datas.Count % ProductViewNumber + 1;
            if (id <= AvalMaxPage) CurrentPage = id;
            else throw new Exception("Page Not Found");
            foreach (var data in datas)
            {
                count++;
                if (count < (id - 1) * ProductViewNumber) continue;
                if (count >= id * ProductViewNumber) break;
                Product_View data_view = new Product_View()
                {
                    trademark = data.trademark.name,
                    category = data.category.name,
                    name = data.name,
                    desciption = data.description,
                    productinfo = data.infoproduct,
                    Price = Money.Parse(data.price),
                    remainquantity = data.quantityremain
                };
                data_view.imageName = Image_Url.urlImage + data.images.First(x => x.productid == data.id).name;
                data_views.Add(data_view);
            }
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