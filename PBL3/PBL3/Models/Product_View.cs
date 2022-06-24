using System.Collections.Generic;
using System.Linq;

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
        public string status;
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
            status = "";
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
            this.description = dataSource.description;
            this.status = dataSource.status;
            this.infoproduct = dataSource.infoproduct;
            this.imageName = Image_Url.urlImage + dataSource.images.First().name;
            this.Price = Money.Parse(dataSource.price);
        }
    }
    public class List_ProductView
    {
        public List<Category> list_categories;
        public List<string> sort;
        public int ProductViewNumber;
        public List<Product_View> data_views;
        public int AvalMaxPage;
        public int CurrentPage;
        public int Amount;
        public List_ProductView()
        {
            list_categories = new List<Category>();
            data_views = new List<Product_View>();
            ProductViewNumber = 6;
            Amount = 0;
            AvalMaxPage = 0;
            CurrentPage = 1;
            sort = new List<string>();
            sort.Add(" ");
            sort.Add(" ");
        }
        public void Set_Product_View(List<Product> datas)
        {
            AvalMaxPage = (datas.Count - 1) / ProductViewNumber + 1;
            foreach (var data in datas)
            {
                Product_View data_view = new Product_View()
                {
                    id = data.id,
                    name = data.name,
                    Price = Money.Parse(data.price),
                    quantityRemain = data.quantityremain,
                    category = data.category.name,
                    trademark = data.trademark.name,
                    description = data.description,
                    infoproduct = data.infoproduct,
                };
                data_view.imageName = Image_Url.urlImage + data.images.First(x => x.productid == data.id).name;
                data_views.Add(data_view);
            }
        }
        public void Set_Product_View2(List<Product> datas)
        {
            Amount = datas.Count;
            foreach (var data in datas)
            {
                Product_View data_view = new Product_View()
                {
                    id = data.id,
                    name = data.name,
                    Price = Money.Parse(data.price),
                    quantityRemain = data.quantityremain,
                    category = data.category.name,
                    trademark = data.trademark.name,
                    description = data.description,
                    infoproduct = data.infoproduct,
                    status = data.status

                };
                data_view.imageName = Image_Url.urlImage + data.images.First(x => x.productid == data.id).name;
                data_views.Add(data_view);
            }
        }

        public List<Product> SortBy(List<string> option, List<Product> datas)
        {
            datas.Reverse();
            this.sort = option;
            if (option[0] != "")
                foreach (var i in this.list_categories)
                {
                    if (option[0] == i.id.ToString() || option[0] == i.name) datas = datas.Where(x => x.categoryid == i.id).ToList();
                }
            switch (option[1])
            {
                case "Lowtohigh":
                    datas = datas.OrderBy(x => x.price).ToList();
                    break;
                case "Hightolow":
                    datas = datas.OrderByDescending(x => x.price).ToList();
                    break;
                case "Larger03":
                    datas = datas.Where(x => x.price > Money.Parse(1000000).Amount).OrderBy(x => x.price).ToList();
                    break;
                case "Less03":
                    datas = datas.Where(x => x.price <= Money.Parse(1000000).Amount).OrderBy(x => x.price).ToList();
                    break;
                case "Less02":
                    datas = datas.Where(x => x.price <= Money.Parse(100000).Amount).OrderBy(x => x.price).ToList();
                    break;
                default:
                    break;
            }
            return datas;
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
        public string status;
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
            status = "";
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
            this.status = dataSource.status;
            this.name = dataSource.name;
            this.imageName = Image_Url.urlImage + dataSource.images.First().name;
            this.Price = Money.Parse(dataSource.price);
        }
    }

}