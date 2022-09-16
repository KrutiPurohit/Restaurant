using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BillSummaryBO
    {
        public string OrderID { get; set; }

        public string OrderDate { get; set; }
        public string RestaurantName { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }

        public string ItemQuantity { get; set; }
        public string ItemPrice { get; set; }
        public string OrderAmount { get; set; }
        public string BillAmount { get; set; }
    }
}
