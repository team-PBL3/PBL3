using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class CartDetail
    {
        public CartDetail()
        { 

        }
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public int cartid { get; set;}
        [Required]
        public int productid { get; set; }
        [Required]
        public int quantitybuy { get; set; }
        public virtual Cart cart { get; set; }
        public virtual Product product { get; set; }
    }
}