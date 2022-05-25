using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class TradeMark
    {
        public TradeMark()
        {
            Products = new List<Product>();
        }
        public int id { get; set; }
        public String name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        
    }
}