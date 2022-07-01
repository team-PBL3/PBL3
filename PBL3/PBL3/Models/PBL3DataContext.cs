using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using MySql.Data.Entity;
using PBL3.Controllers;

namespace PBL3.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PBL3DataContext : DbContext
    {
        public PBL3DataContext(): base("Pbl3DataContextConnectionString")
        {
            
        }    
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Orderdetail> Orderdetails { get; set; }
        public DbSet<Orderr> Orderrs { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TradeMark> TradeMarks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin_Action_History> Admin_Actions_History { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public int Adding(User user)
        {
            try
            {
                Cart cart = new Cart() { user = user, quantityBuy = 0};
                this.Carts.Add(cart);
                return this.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    
                }
                throw;
            }
        }
        public int Edit(User user)
        {
            try
            {
                User a = this.Users.First(i => i.id == user.id);
                if (user.name != null) a.name = user.name;
                if (user.username != null) a.username = user.username;
                if (user.sex != null) a.sex = user.sex;
                if (user.phone !="0")a.phone = user.phone;
                if (user.address != null) a.address = user.address;
                if (user.password != null) a.password = user.password;
                return this.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
        }
        public int Adding(Category category)
        {
            try
            {
                foreach (var i in this.Categories.ToList())
                    if (i.name == category.name && i.partofbody == category.partofbody) throw new Exception("This category have existed");
                this.Categories.Add(category);
                return this.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int Adding(Product product)
        {
            try
            {
                product.status = "ACTIVE";
                foreach (var i in this.Products.ToList())
                    if (i.name == product.name) throw new Exception("This product have existed");
                this.Products.Add(product);
                return this.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
        }
        public int Adding(CartDetail cartDetail)
        {
            try
            {
                this.CartDetails.Add(cartDetail);
                return this.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }   
        public int Edit2(Orderr orderr)
        {
            try
            {
                if (orderr.status == "Đã xác nhận")
                    foreach (var i in orderr.orderdetails)
                    {
                        Orderdetail od = i;
                        i.product.statistics.Last().income += i.quantity;
                        i.product.statistics.Last().pending -= i.quantity;
                    }
                        
                Orderr orderr1 = this.Orderrs.First(i => i.id == orderr.id);
                orderr1.status = orderr.status;
                return this.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
        }
        public int Edit(Product product, string imagee, User user)
        {
            if (imagee == "") imagee = this.Images.ToList().First(x => x.id == product.id).name;
            else this.Products.ToList().First(x => x.id == product.id).images.First().name = imagee;
            this.Products.ToList().First(x => x.id == product.id).name = product.name;
            this.Products.ToList().First(x => x.id == product.id).categoryid = product.categoryid;
            this.Products.ToList().First(x => x.id == product.id).trademarkid = product.trademarkid;
            this.Products.ToList().First(x => x.id == product.id).description = product.description;
            this.Products.ToList().First(x => x.id == product.id).price = product.price;
            this.Products.ToList().First(x => x.id == product.id).quantityInit = product.quantityInit;
            this.Products.ToList().First(x => x.id == product.id).images.First().name = imagee;

            Admin_Action_History admin_Action_History = new Admin_Action_History();
            admin_Action_History.CreateBy = user.id;
            admin_Action_History.EditBy = user.id;
            admin_Action_History.actionType = ActionType.Update;
            admin_Action_History.impactedObjectType = ImpactedObjectType.Product;
            admin_Action_History.ActionTime = DateTime.Now;
            admin_Action_History.impactedObjectTypeId = product.id;
            this.Admin_Actions_History.Add(admin_Action_History);

            try
            {
                return this.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {

                }
                throw;
            }

        }

        public int Delete(int productId)
        {
            Product product = this.Products.First(x => x.id == productId);
            product = this.Products.Remove(product);
            return this.SaveChanges();
        }
        public int DeleteCD(int id)
        {
            try
            {
                this.CartDetails.Remove(this.CartDetails.First(i => i.id == id));
                return this.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }    
        public int DeleteCDAll()
        {
            try
            {
                foreach( var i in this.CartDetails)
                this.CartDetails.Remove(i);
                return this.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }    
        public int Adding(Orderdetail orderdetail)
        {
            try
            {

                this.Orderdetails.Add(orderdetail);
                return this.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CreateOrder(List<Orderdetail> LOD, User user, List<int> CDid, Person toPerson)
        {
            try
            {
                Orderr order = new Orderr() { status = "Đã xác nhận", TimeUpdate = DateTime.Now, userid = user.id, TimeConfirm = DateTime.Now, Person = toPerson };
                Adding(order);
                int Oid = this.Orderrs.ToList().Last().id;
                int count = 0;
                double total = 0;
                foreach (var OD in LOD)
                {
                    Statistics temp = this.Statistics.OrderByDescending(t=>t.id).First(t => t.productid == OD.productid);
                    temp.pending += (OD.price);
                    this.Products.First(x => x.id == OD.productid).quantityremain -= OD.quantity;
                    this.SaveChanges();
                    OD.orderid = Oid;
                    Adding(OD);
                    count += OD.quantity;
                    total += (OD.price * OD.quantity);
                }
                Payment b;
                b = new Payment() { amount = count, paymentdate = DateTime.Now, totalPrice = total, orderid = Oid, userid = user.id };
                Adding(b);

                if (CDid!=null)
                foreach (var id in CDid)
                {
                    this.CartDetails.Remove(this.CartDetails.ToList().First(x => x.id == id));
                }
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
        }    
        public int Adding(Orderr orderr)
        {
            try
            {
                this.Orderrs.Add(orderr);
                return this.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        } 
        public int DeleteOrder(int Orderid)
        {
            this.Orderrs.Remove(this.Orderrs.First(x => x.id == Orderid));
            return this.SaveChanges();
        }    
        public int Update(Orderr orderr)
        {
            try
            {
                if (orderr.status != null && orderr.status != "" && this.Orderrs.First(x => x.id == orderr.id).status != orderr.status) this.Orderrs.First(x => x.id == orderr.id).status = orderr.status;
                this.Orderrs.First(x => x.id == orderr.id).TimeUpdate = DateTime.Now;
                return this.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Adding(Payment payment)
        {
            try
            {
                this.Payments.Add(payment);
                return this.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int Adding(Person person)
        {
            try
            {
                this.Persons.Add(person);
                return this.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Adding(TradeMark trademark)
        {
            try
            {
                foreach (var i in this.TradeMarks.ToList())
                    if (i.name == trademark.name) throw new Exception("This trademark have existed");
                this.TradeMarks.Add(trademark);
                return this.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public double TotalPrice()
        {
            double total = 0; ;
            foreach(var i in this.Statistics.ToList())
            {
                total += i.total;

            }
            return total;
        }
        public void UpdatePW(User user, string pwmuondoi)
        {

            this.Users.First(i => i.id == user.id).password = pwmuondoi;
            this.SaveChanges();
        }
        public User CheckExistingEmail(User user)
        {
            try
            {
                return this.Users.First(i => i.email == user.email && i.name == user.name &&
                i.username == user.username && i.phone == user.phone);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}