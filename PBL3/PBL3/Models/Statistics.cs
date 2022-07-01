using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Statistics
    {
        public Statistics()
        {

        }
        [Key]
        public int id { get; set; }
        [ForeignKey("product")]
        public int productid { get; set; }
        public double income { get; set; }
        public double pending { get; set; }
        public double total {
            get { return income + pending; }
            set {; }
        }
        public string period { get; set; }
        public virtual Product product { get; set; }
    }
}