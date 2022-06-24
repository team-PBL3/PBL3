using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3.Models
{
    public class Account_Sign_Up
    {
        public Account_Sign_Up()
        {

        }
        [Required]
        public String name { get; set; }
        [Required]
        public String sex { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public String address { get; set; }
        [Required]
        [Remote(action: "Check_Existing_UserName", controller: "Login", ErrorMessage = "This username already existed.")]
        public String username { get; set; }
        [Required]
        [EmailAddress]
        [Remote("Check_Existing_Email", "Login", AdditionalFields = "email", ErrorMessage = "Email already existed!")]
        public String email { get; set; }
        [Required]
        [MaxLength(12,ErrorMessage = "Password length would have less or equals 12 characters")]
        [MinLength(6, ErrorMessage = "Password length would have longer or equals 6 characters")]
        public String password { get; set; }
        [Remote(action: "Is_Matched_Passwork", controller: "Login", AdditionalFields = "password", ErrorMessage = "The passwords don't match")]
        public string cfpassword { get; set; }
    }
}