using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace PBL3.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        [Key]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String partofbody { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}