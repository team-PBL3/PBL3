using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class CartDetail_View
    {
        public int id;
        public Product_View product_view;
        public int quantity;
        public int quantityRemain;
        public CartDetail_View()
        {
            id = 0;
            product_view = new Product_View();
            quantity = 0;
        }    
        public void SetCartDetail(int id)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            CartDetail a = dataContext.CartDetails.First(x => x.id == id);
            this.id = id;
            this.product_view.id = a.product.id;
            this.product_view.name = a.product.name;
            this.product_view.Price = Money.Parse(a.product.price);
            this.product_view.imageName = a.product.images.First().name;
        }
    }
    public class List_CD_View
    {
        public Cart cart;
        public List<CartDetail_View> dataViews;
        public List_CD_View(Cart cart)
        {
            this.cart = cart;
            dataViews = new List<CartDetail_View>();
        }
        public List_CD_View(int cartid)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            this.cart = dataContext.Carts.First(t=>t.id == cartid);
            dataViews = new List<CartDetail_View>();
        }
        public void Set_CD_View()
        {
            foreach(var i in cart.cartdetails.ToList())
            {
                CartDetail_View x = new CartDetail_View()
                {
                    id = i.id,
                    quantity = i.quantitybuy
                };
                x.product_view = new Product_View()
                {
                    id = i.productid,
                    imageName = i.product.images.First().name,
                    name = i.product.name,
                    Price = Money.Parse(i.product.price),
                    quantityRemain = i.product.quantityremain,
                }; 
                dataViews.Add(x);
            }    
        }
        public void Set_CD_View(List<int> CDid, List<int> quantity_input)
        {
            List<CartDetail> data = cart.cartdetails.ToList();
            for (int i =0; i<CDid.Count;i++)
            {
                var x = data.First(t => t.id == CDid.ElementAt(i));
                this.dataViews.Add(new CartDetail_View()
                {
                    id = x.id,
                    quantity = quantity_input.ElementAt(i),
                    product_view = new Product_View()
                    {
                        id = x.productid,
                        name = x.product.name,
                        Price = Money.Parse(x.product.price),
                        imageName = x.product.images.First().name,
                        quantityRemain = x.product.quantityremain,
                    },
                });
            }
        }
    }    
}