using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class OrderView
    {
        public Orderr order;
        public string image;
        public OrderView(Orderr order)
        {
            this.order = order;
            this.image = Image_Url.urlImage + order.orderdetails.First().product.images.First().name;
        }    
    }
    public class ListOrderView
    {
        public List<OrderView> list;
        public ListOrderView(List<Orderr> listdata)
        {
            foreach(var item in listdata)
            {
                list = new List<OrderView>();
                list.Add(new OrderView(item));
            }    
        }    
    }
}