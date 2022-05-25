using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Product
    {
        public Product()
        {
            images = new List<Image>();
            orderdetails = new List<Orderdetail>();
            cartdetails = new List<CartDetail>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public int categoryid { get; set; }
        public int trademarkid { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string status { get; set; }
        public string infoproduct { get; set; }
        public int quantityremain { get; set; }
        public virtual Category category { get; set; }
        public virtual TradeMark trademark { get; set; }
        public virtual ICollection<Image> images { get; set; }
        public virtual ICollection<Orderdetail> orderdetails { get; set; }
        public virtual ICollection<CartDetail> cartdetails { get; set; }
    }
    
}