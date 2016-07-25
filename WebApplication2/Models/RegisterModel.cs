using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RegisterModel
    {

        [Required]
        [Display(Name = "اسم المستخدم")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "الرقم السري")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "الصورة الرمزية")]
        public string Picture { get; set; }
        [Required]
        [Display(Name = "المدينة")]
        public string City { get; set; }
        [Required]
        [Display(Name = "الدولة")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "رقم الجوال")]
        public string Mobile { get; set; }


    }
}