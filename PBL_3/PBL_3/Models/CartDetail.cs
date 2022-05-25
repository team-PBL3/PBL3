using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class CartDetail
    {
        public CartDetail()
        { 

        }
        public int id { get; set;}
        public int cartid { get; set;}
        public int productid { get; set; }
        public int quantitybuy { get; set; }
        public virtual Cart cart { get; set; }
        public virtual Product product { get; set; }
    }
}