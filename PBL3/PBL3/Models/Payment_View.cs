using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Payment_View
    {
        public User Account;
        public Person person;
        public List<Orderdetail> LOD;
        public Money TotalPrice;

        public Payment_View()
        {
            Account = new User();
            person = new Person();
            TotalPrice = Money.Parse(0);
            LOD = new List<Orderdetail>();
        }    
        public Payment_View(User user)
        {
            Payment a = new PBL3DataContext().Payments.ToList().Last(x => x.userid == user.id);
            Account = a.User;
            TotalPrice = Money.Parse(0);
            person = a.order.Person;
            LOD = new List<Orderdetail>();
            foreach (var i in a.order.orderdetails)
            {
                LOD.Add(i);
                TotalPrice.Amount += i.price;
            }    
        }
        public Payment_View(int orderid)
        {
            LOD = new List<Orderdetail>();
            Payment a = new PBL3DataContext().Orderrs.First(x => x.id == orderid).payments.Last();
            person = a.order.Person;
            Account = a.User;
            TotalPrice = Money.Parse(0);
            foreach (var i in a.order.orderdetails)
            {
                LOD.Add(i);
                TotalPrice.Amount += i.price;
            }
        }
    }
}