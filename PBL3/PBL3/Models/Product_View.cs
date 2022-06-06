using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public static class Image_Url
    {
        public const string urlImage = "/Image/";
    }    
    public class Product_View
    {
        public int id;
        public string name;
        public string imageName;
        public string description;
        public string category;
        public string trademark;
        public string infoproduct;
        public int quantityRemain;
        public Money Price;
        public Product_View()
        {
            id = 0;
            name = "";
            imageName = "";
            category = "";
            trademark = "";
            infoproduct = "";
            quantityRemain = 0;
            description = "";
            Price = new Money("VND");
        }
        public void Set_Product_View(int productid)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            Product dataSource = dataContext.Products.First(x => x.id == productid);
            this.id = productid;
            this.name = dataSource.name;
            this.quantityRemain = dataSource.quantityremain;
            this.imageName = Image_Url.urlImage + dataSource.images.First().name;
            this.Price = Money.Parse(dataSource.price);
        }
    }
    public class List_ProductView
    {
        public static int ProductViewNumber = 6;
        public List<Product_View> data_views;
        public int AvalMaxPage;
        public int CurrentPage;
        public List_ProductView()
        {
            data_views = new List<Product_View>();
            AvalMaxPage = 0;
            CurrentPage = 1;
        }
        public void Set_Product_View(int page, List<Product> datas)
        {
            int count = -1;
            AvalMaxPage = (datas.Count-1) / ProductViewNumber + 1;
            if (page <= AvalMaxPage) CurrentPage = page;
            else throw new Exception("Page Not Found");
            foreach (var data in datas)
            {
                count++;
                if (count < (page - 1) * ProductViewNumber) continue;
                if (count >= page * ProductViewNumber) break;
                Product_View data_view = new Product_View()
                {
                    id = data.id,
                    name = data.name,
                    Price = Money.Parse(data.price),
                    quantityRemain = data.quantityremain,
                };
                data_view.imageName = Image_Url.urlImage + data.images.First(x => x.productid == data.id).name;
                data_views.Add(data_view);
            }
        }
        public void SortBy(string option)
        {
            switch (option)
            {
                case "Lowtohigh":
                    this.data_views = this.data_views.OrderBy(x => x.Price.Amount).ToList();
                    break;
                case "Hightolow":
                    this.data_views = this.data_views.OrderByDescending(x => x.Price.Amount).ToList();
                    break;
                case "Larger03":
                    this.data_views = this.data_views.Where(x => x.Price.Amount > Money.Parse(1000000).Amount).OrderBy(x => x.Price.Amount).ToList();
                    break;
                case "Less03":
                    this.data_views = this.data_views.Where(x => x.Price.Amount <= Money.Parse(1000000).Amount).OrderBy(x => x.Price.Amount).ToList();
                    break;
                case "Less02":
                    this.data_views = this.data_views.Where(x => x.Price.Amount <= Money.Parse(100000).Amount).OrderBy(x => x.Price.Amount).ToList();
                    break;
                default:
                    break;
            }
        }    
    }
    public class Product_View_Detail
    {
        public int id;
        public string trademark;
        public string category;
        public string desciption;
        public string productinfo;
        public int remainquantity;
        public string name;
        public string imageName;
        public Money Price;
        public Product_View_Detail()
        {
            id = 0;
            trademark = "";
            category = "";
            desciption = "";
            productinfo = "";
            remainquantity = 0;
            name = "";
            imageName = "";
            Price = new Money("VND");
        }
        public void Set_Product_Detail(int productid)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            Product dataSource = dataContext.Products.First(x => x.id == productid);
            this.id = productid;
            this.trademark = dataSource.trademark.name;
            this.category = dataSource.category.name;
            this.desciption = dataSource.description;
            this.productinfo = dataSource.infoproduct;
            this.remainquantity = dataSource.quantityremain;
            this.name = dataSource.name;
            this.imageName = Image_Url.urlImage+dataSource.images.First().name;
            this.Price = Money.Parse(dataSource.price);
        }    
    }
      
}