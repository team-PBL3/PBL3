using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class User
    {
        public User()
        {
            orders = new List<Orderr>();
            carts = new List<Cart>();

        }
        public int id { get; set; }
        public String name { get; set; }
        public String sex { get; set; }
        public int phone { get; set; }
        public String address { get; set; }
        public String username { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String status { get; set; }
        public int roleid { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Cart> carts { get; set; }
        public virtual ICollection<Orderr> orders { get; set; }
    }

}