using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Models
{
    public class Account_Sign_in
    {
        public Account_Sign_in()
        {

        }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DataType(DataType.EmailAddress)]
        //[Remote("IsExistAccount","Login",AdditionalFields="password",ErrorMessage ="The email or password is wrong")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public static User Check_Signing_In(List<User> users, string email, string password)
        {
            //password = Encrypt.ToEncrypt(password);
            if (!users.Any(x => x.email == email && x.password == password)) throw new Exception("Email or password is wrong, please checking again.");
            User i = null;
            i = users.First(x => x.email == email && x.password == password);
            return i;
        }    
    }
}
