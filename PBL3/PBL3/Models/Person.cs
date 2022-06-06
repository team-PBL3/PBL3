using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [Remote("Check_Number","Order",ErrorMessage ="Phone must contain only numbers")]
        public string phone { get; set; }
        [Required]
        public String address { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public String email { get; set; }
    }
}