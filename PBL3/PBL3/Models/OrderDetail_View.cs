using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class OrderDetail_View
    {
        public Product_View product_view;
        public int quantity;
        public int id;
        public OrderDetail_View()
        {
            product_view = new Product_View();
            quantity = 0;
            id = 0;
        }
    }
    public class List_OD_View
    {
        public List<OrderDetail_View> list;
        public List_OD_View()
        {
            list = new List<OrderDetail_View>();
        }
        public void Set_LOD_View(List<int> CDid, List<int> quantity_input, int cartid)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            List<CartDetail> data = dataContext.Carts.First(t=>t.id==cartid).cartdetails.ToList();
            foreach (var i in CDid)
            {
                var x = data.First(t => t.id == i);
                this.list.Add(new OrderDetail_View()
                {
                    quantity = quantity_input.ElementAt(i),
                    product_view = new Product_View()
                    {
                        id = x.productid,
                        name = x.product.name,
                        Price = Money.Parse(x.product.price),
                    },
                });
            }
        }
    }    
}