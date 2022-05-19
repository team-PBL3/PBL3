using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Errors
    {
    }
    public class SignUp_Errors  //class ghi lỗi của controller Sign up
    {
        public string Name;
        public string Sex;
        public string Address;
        public string Phone;
        public string Username;
        public string Email;
        public string Password;
        public string Cfpassword;
        public string result;
        public SignUp_Errors()
        {
            Name = "";
            Sex = "";
            Address = "";
            Phone = "";
            Username = "";
            Email = "";
            Password = "";
            Cfpassword = "";
            result = "";
        }
    }
}