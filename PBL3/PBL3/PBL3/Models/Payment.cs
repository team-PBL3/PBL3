using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Payment
    {
        public Payment()
        {

        }
        [Key]
        public int id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime paymentdate { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public double totalPrice { get; set; }
        [Required]
        public int orderid { get; set; }
        public virtual Orderr order { get; set; }
    }
}