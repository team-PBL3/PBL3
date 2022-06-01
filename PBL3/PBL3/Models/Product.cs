using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int categoryid { get; set; }
        [Required]
        public int trademarkid { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public string infoproduct { get; set; }
        [Required]
        public int quantityremain { get; set; }
        [Required]
        public int quantityInit { get; set; }
        public virtual Category category { get; set; }
        public virtual TradeMark trademark { get; set; }
        public virtual ICollection<Image> images { get; set; }
        public virtual ICollection<Orderdetail> orderdetails { get; set; }
        public virtual ICollection<CartDetail> cartdetails { get; set; }
    }

    
}