using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class CuisineBO
    {
        public int CuisineID { get; set; }

        [Display(Name = "Restaurant Name")]
        public int RestaurantID { get; set; }

        public string RestaurantName { get; set; }

        [Display(Name = "Cuisine Name")]
        [Required(ErrorMessage = "Cuisine Name is required")]
        public string CuisineName { get; set; }

        public List<SelectListItem> RestaurantNames { get; set; }
    }
}
