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
        [Remote(action: "Check_Existing_UserName", controller: "Login", ErrorMessage = "Tên này đã được sử dụng.")]
        public String username { get; set; }
        [Required]
        [EmailAddress]
        [Remote("Check_Existing_Email", "Login", AdditionalFields = "email", ErrorMessage = "Email này đã được sử dụng.")]
        public String email { get; set; }
        [Required]
        [MaxLength(14,ErrorMessage = "Độ dài của mật khẩu nên gồm 8-14 ký tự")]
        [MinLength(8, ErrorMessage = "Độ dài của mật khẩu nên gồm 8-14 ký tự")]
        [Remote("Check_Val_Pwd", "Login", ErrorMessage = "Mật khẩu nên có ít nhất một ký tự số, viết hoa và ký tự đặc biệt.")]
        public String password { get; set; }
        [Remote(action: "Is_Matched_Passwork", controller: "Login", AdditionalFields = "password", ErrorMessage = "Mật khẩu nhập lại không chính xác!")]
        public string cfpassword { get; set; }
    }
}