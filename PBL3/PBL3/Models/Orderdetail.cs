﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Orderdetail
    {
        public Orderdetail()
        {

        }
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public int orderid { get; set; }
        public int productid { get; set; }
        public virtual Orderr order { get; set; }
        public virtual Product product { get; set; }
    }
}