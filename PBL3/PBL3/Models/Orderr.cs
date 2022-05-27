﻿using System;
using System.Collections.Generic;
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
        public int id { get; set; }
        public String name { get; set; }
        public String status { get; set; }
        public int userid { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Orderdetail> orderdetails { get; set; }
        public virtual ICollection<Payment> payments { get; set; }
    }
}