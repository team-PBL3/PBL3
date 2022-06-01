using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Person
    {
        public Person()
        {

        }
        [Key]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String sex { get; set; }
        [Required]
        public int phone { get; set; }
        [Required]
        public String address { get; set; }
        [Required]
        public String email { get; set; }
    }
}