using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Image
    {
        public Image()
        {

        }    
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int productid { get; set; }
        public virtual Product product { get; set; }
    }
}