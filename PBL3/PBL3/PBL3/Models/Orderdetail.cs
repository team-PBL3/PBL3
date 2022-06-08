using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Orderdetail
    {
        public Orderdetail()
        {

        }
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public int orderid { get; set; }
        public int productid { get; set; }
        public virtual Orderr order { get; set; }
        public virtual Product product { get; set; }
    }
}