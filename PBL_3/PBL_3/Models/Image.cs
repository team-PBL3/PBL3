using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Image
    {
        public Image()
        {

        }    
        public int id { get; set; }
        public string name { get; set; }
        public int productid { get; set; }
        public virtual Product product { get; set; }
    }
}