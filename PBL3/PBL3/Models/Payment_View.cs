using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Payment_View
    {
        public string address;
        public string phone;
        public string nameCustomer;
        public List<Orderdetail> LOD;
        public Money TotalPrice;

        public Payment_View()
        {
            address = "";
            phone = "";
            nameCustomer = "";
            TotalPrice = Money.Parse(0);
            LOD = new List<Orderdetail>();
        }    
        public Payment_View(User user)
        {
            Payment a = new PBL3DataContext().Payments.ToList().Last(x => x.userid == user.id);
            address = a.User.address;
            phone=a.User.phone;
            nameCustomer=a.User.name;
            TotalPrice = Money.Parse(0);
            LOD = new List<Orderdetail>();
            foreach (var i in a.order.orderdetails)
            {
                LOD.Add(i);
                TotalPrice.Amount += i.price;
            }    
        }
        public Payment_View(int orderid)
        {
            Payment a = new PBL3DataContext().Orderrs.First(x => x.id == orderid).payments.Last();
            address = a.User.address;
            phone = a.User.phone;
            nameCustomer = a.User.name;
            TotalPrice = Money.Parse(0);
            foreach (var i in a.order.orderdetails)
            {
                LOD.Add(i);
                TotalPrice.Amount += i.price;
            }
        }
    }
}