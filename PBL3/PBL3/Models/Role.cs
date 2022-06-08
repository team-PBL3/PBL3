using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }
        public int id { get; set; }
        public String value { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}