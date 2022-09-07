using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class OrderBO
    {
        public int OrderID { get; set; }
        [Display(Name ="Order Date")]
        [Required(ErrorMessage ="Order Date is required")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Restaurant ID")]
        [Required(ErrorMessage = "Restaurant is required")]
        public int RestaurantID { get; set; }

        [Display(Name = "Menu Item ID")]
        [Required(ErrorMessage = "Menu ITem is required")]
        public int MenuItemID { get; set; }

        [Display(Name = "Item Quantity")]
        [Required(ErrorMessage = "Item Quantity is required")]
        public int ItemQuantiy { get; set; }

        [Display(Name = "Order Amount")]
        [Required(ErrorMessage = "Order Amount is required")]
        public float OrderAmount { get; set; }

        [Display(Name = "Dining Table ID")]
        [Required(ErrorMessage = "Dining Table is required")]
        public int DiningTableID { get; set; }
    }
}
