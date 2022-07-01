using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Statistic_View
    {
        public Statistics statistics;
        public double Ppending;
        public double Psold;
        public double Ptotal;
        public Statistic_View()
        {

        }
        public Statistic_View(Statistics statistics)
        {
            this.statistics = statistics;
            this.Ppending = statistics.product.orderdetails.Where(i=>i.order.status!="Đã hoàn thành").Sum(i => i.quantity);
            this.Psold = statistics.product.quantityInit - statistics.product.quantityremain;
            this.Ptotal = statistics.product.quantityInit;
        }
    }
    public class L_Statistic_View
    {
        public List<Statistic_View> Stview;
        public L_Statistic_View()
        {

        }
        public L_Statistic_View(List<Statistics> list)
        {
            Stview = new List<Statistic_View>();
            foreach(var i in list)
            {
                Stview.Add(new Statistic_View(i));
            }    
        }
    }    
}