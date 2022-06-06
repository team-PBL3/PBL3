using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Product_Display
    {
        public string Name;
        public string urlImage;
        public Money Price;
        public Product_Display()
        {
            Name = "";
            urlImage = "";
            Price = new Money("VND");
        }
        public Product_Display(string name, string url, float price)
        {
            Name = name;
            urlImage = url;
            Price = new Money("VND");
            Price.Amount = price;
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