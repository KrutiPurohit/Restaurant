using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class CustomerBO
    {
        public int CustomerID { get; set; }

        public int RestaurantID { get; set; }

        [Display(Name = "Customer Name")]
        [MinLength(10)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid Customer Name")]
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Mobile Number.")]
        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobileNo { get; set; }

        public IEnumerable<SelectListItem> RestaurantNames { get; set; }

    }
}
