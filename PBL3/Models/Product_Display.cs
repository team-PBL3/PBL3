using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Product_Display
    {
        public int id;
        public string Name;
        public string urlImage;
        public Money Price;
        public Product_Display()
        {
            id = 0;
            Name = "";
            urlImage = "";
            Price = new Money("VND");
        }
        public Product_Display(Product datasource)
        {
            id = datasource.id;
            Name = datasource.name;
            urlImage = Image_Url.urlImage + datasource.images.First().name;
            Price = new Money("VND");
            Price.Amount = datasource.price;
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
            return new Money() { Amount = amount };
        }
    }
}