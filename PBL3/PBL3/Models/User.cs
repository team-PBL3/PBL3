using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Models
{
    public enum Genber
    {
        Nam=0,
        Nu=1
    }
    public class User
    {
        public User()
        {
            orders = new List<Orderr>();
            carts = new List<Cart>();

        }
        [Key]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String sex { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public String address { get; set; }
        [Required]
        public String username { get; set; }
        [Required]
        [EmailAddress]
        public String email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String password { get; set; }
        [Required]
        public String status { get; set; }
        [Required]
        public int roleid { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Cart> carts { get; set; }
        public virtual ICollection<Orderr> orders { get; set; }
    }
}