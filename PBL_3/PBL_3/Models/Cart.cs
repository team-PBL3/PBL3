using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class Cart
    {
        public Cart()
        {
            cartdetails = new List<CartDetail>();
        }
        [Key]
        public int id { get; set; }
        public int quantityBuy { get; set; }
        public virtual User user { get; set; }
        public virtual ICollection<CartDetail> cartdetails { get; set; }
    }
}