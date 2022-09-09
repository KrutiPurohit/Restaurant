using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BusinessObjects.Common;
using System.Web.Mvc;

namespace BusinessObjects 
{
    public class OrderBO
    {
        public int OrderID { get; set; }

        [DataType(DataType.Date)]
        [CurrentDate(ErrorMessage = "Order date must be today's date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Order Date")]
        [Required(ErrorMessage ="Order Date is required")]
        public DateTime OrderDate { get; set; }

        public int RestaurantID { get; set; }
        public int MenuItemID { get; set; }

       
        [Display(Name = "Item Quantity")]
        [RegularExpression(@"^[1-9]*$", ErrorMessage = "Invalid Quantity.")]
        [Required(ErrorMessage = "Item Quantity is required")]
        public int ItemQuantiy { get; set; }

        [Display(Name = "Order Amount")]
        public float OrderAmount { get; set; }
     
        public int DiningTableID { get; set; }

        public IEnumerable<SelectListItem> RestaurantNames { get; set; }
        public IEnumerable<SelectListItem> DiningTableLocations { get; set; }
        public IEnumerable<SelectListItem> MenuItemNames { get; set; }
    }
}
