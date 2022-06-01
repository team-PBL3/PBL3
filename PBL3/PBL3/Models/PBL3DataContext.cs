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
            catch (Exception)
            {
                throw;
            }
        }
        
        
        public int Adding(CartDetail cartDetail)
        {
            try
            {
                cartDetail.Time = DateTime.Now;
                this.CartDetails.Add(cartDetail);
                return this.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Adding(Orderdetail orderdetail)
        {
            try
            {
                orderdetail.Time = DateTime.Now;
                this.Orderdetails.Add(orderdetail);
                return this.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Adding(Orderr orderr)
        {
            try
            {
                orderr.TimeConfirm = DateTime.Now;
                orderr.status = "Waiting for confirmation.";
                this.Orderrs.Add(orderr);
                return this.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        } 
        public int Update(Orderr orderr)
        {
            try
            {
                if (orderr.name != null && orderr.name != "" && this.Orderrs.First(x => x.id == orderr.id).name != orderr.name) this.Orderrs.First(x => x.id == orderr.id).name = orderr.name;
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
    }
}