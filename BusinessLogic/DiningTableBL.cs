using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccess;

namespace BusinessLogic
{
   public class DiningTableBL
    {
        public IEnumerable<SelectListItem> GetDiningTableLocations()
        {
            return new DiningTableDAL().GetAllDiningTableLocations();
        }
        public IEnumerable<SelectListItem> GetDiningTableLocations(int restaurantID)
        {
            return new DiningTableDAL().GetAllDiningTableLocations(restaurantID);
        }
    }
}
