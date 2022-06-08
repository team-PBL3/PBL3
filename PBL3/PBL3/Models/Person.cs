using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Person
    {
        public Person()
        {

        }
        public int id { get; set; }
        public String name { get; set; }
        public String sex { get; set; }
        public int phone { get; set; }
        public String address { get; set; }
        public String email { get; set; }
    }
}