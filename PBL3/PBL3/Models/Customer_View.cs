using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Customer_View
    {
        public int id;
        public String name;
        public String sex;
        public String phone;
        public String address;
        public String username;
        public String email;
        public String password;
        public String status;
        public String Role;
        public Customer_View()
        {
            id = 0;
            name = "";
            sex = "";
            phone = "";
            address = "";
            username = "";
            email = "";
            password = "";
            status = "";
            Role = "";

        }
        public void Set_Customer_View(int userid)
        {
            PBL3DataContext dataContext = new PBL3DataContext();
            User dataSource = dataContext.Users.First(x => x.id == userid);
            this.id = userid;
            this.name = dataSource.name;
            this.sex = dataSource.sex;
            this.phone = dataSource.phone;
            this.address = dataSource.address;
            this.username = dataSource.username;
            this.email = dataSource.email;
            this.password = dataSource.password;
            this.status = dataSource.status;
            this.Role = dataSource.Role.value;
        }



    }
    public class List_CustomerView
    {
        public static int CustomerViewNumber = 6;
        public List<Customer_View> data_views;
        public int AvalMaxPage;
        public int CurrentPage;
        public List_CustomerView()
        {
            data_views = new List<Customer_View>();
            AvalMaxPage = 0;
            CurrentPage = 1;
        }
        public void Set_Customer_View(int page, List<User> datas)
        {
            int count = -1;
            AvalMaxPage = (datas.Count - 1) / CustomerViewNumber + 1;
            if (page <= AvalMaxPage) CurrentPage = page;
            else throw new Exception("Page Not Found");
            foreach (var data in datas)
            {
                if (data.Role.value == "ADMIN")
                {
                    continue;
                }
                Customer_View customer_View = new Customer_View()
                {
                    id = data.id,
                    name = data.name,
                    sex = data.sex,
                    phone = data.phone,
                    address = data.address,
                    username = data.username,
                    email = data.email,
                    password = data.password,
                    status = data.status,
                    Role = data.Role.value,
                };

                data_views.Add(customer_View);
            }
        }


    }
}