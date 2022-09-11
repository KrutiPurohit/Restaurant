using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class DiningTableTrackBO
    {
        public int DiningTableTrackID { get; set; }
        public int DiningTableID { get; set; }
        public string TableStatus { get; set; }
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string Location { get; set; }
    }
}
