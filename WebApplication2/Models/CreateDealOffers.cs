using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CreateDealOffers
    {

        [Required]
        [Display(Name = "العملة")]
        public string Currency1 { get; set; }
        [Required]
        [Display(Name = "السعر")]
        public int Price1 { get; set; }
        [Required]
        [Display(Name = "الوزن")]
        public int Weight1 { get; set; }
        [Required]
        [Display(Name = "مكان الوصول")]
        public string ArrivalCity1 { get; set; }
        [Required]
        [Display(Name = "مكان المغادرة")]
        public string DepartureCity1 { get; set; }
        [Required]
        [Display(Name = "وقت الوصول")]
        public TimeSpan ArrivalTime1 { get; set; }
        [Required]
        [Display(Name = "وقت المغادرة")]
        public TimeSpan DepartureTime1 { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "تاريخ الوصول")]
        public DateTime ArrivalDate1 { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "تاريخ المغادرة")]
        public DateTime DepartureDate1 { get; set; }
        [Required]
        [Display(Name = "طريقة الإستلام")]
        public String ReceiveMethod1 { get; set; }
        [Required]
        [Display(Name = "طريقة التسليم")]
        public String DeliveryMethod1 { get; set; }
        [Required]
        [Display(Name = "قابلية التفاوض في التسليم")]
        public Boolean Flexibility1 { get; set; }

    }
}