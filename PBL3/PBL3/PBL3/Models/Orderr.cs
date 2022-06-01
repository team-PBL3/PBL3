using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Orderr
    {
        public Orderr()
        {
            orderdetails = new List<Orderdetail>();
            payments = new List<Payment>();
        }
        [Key]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String status { get; set; }
        [Required]
        public DateTime TimeConfirm { get; set; }
        [Required]
        public DateTime TimeUpdate { get; set; }
        [Required]
        public int userid { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Orderdetail> orderdetails { get; set; }
        public virtual ICollection<Payment> payments { get; set; }
    }
}