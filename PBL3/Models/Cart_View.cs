using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Cart_View
    {
        PBL3DataContext dataContext;
        public Cart cart;
        public List_CD_View lViews;
        public Cart_View(Cart cart)
        {
            lViews = new List_CD_View(cart);
            lViews.Set_CD_View();
            this.cart = cart;
            dataContext = new PBL3DataContext();
        }    
        public void AddToCart(int productid)
        {
            if (dataContext.CartDetails.Any(x => x.productid == productid && x.cartid == cart.id))
                throw new Exception("HaveExsit");
            CartDetail cartDetail = new CartDetail();
            cartDetail.cartid = cart.id;
            cartDetail.productid = productid;
            cartDetail.quantitybuy = 1;
            cartDetail.Time = DateTime.Now;
            if (dataContext.Adding(cartDetail) == 0) throw new Exception("FailedToAdd");
        }
    }
}