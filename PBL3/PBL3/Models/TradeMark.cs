using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Models
{
    public class TradeMark
    {
        public TradeMark()
        {
            Products = new List<Product>();
        }
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        
    }
}