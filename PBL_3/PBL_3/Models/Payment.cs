using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Payment
    {
        public Payment()
        {

        }
        public int id { get; set; }
        public String paymentdate { get; set; }
        public int amount { get; set; }
        public double totalPrice { get; set; }
        public int orderid { get; set; }
        public virtual Orderr order { get; set; }
    }
}