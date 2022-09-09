using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class BillsBO
    {
        [Display(Name = "Order Number (ID)")]
        public int OrderID { get; set; }

        [Display(Name = "Customer")]
        public int CustomerID { get; set; }

        public IEnumerable<SelectListItem> OrderIDs { get; set; }

        public IEnumerable<SelectListItem> CustomerNames { get; set; }
    }
}
