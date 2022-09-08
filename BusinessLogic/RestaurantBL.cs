using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccess;

namespace BusinessLogic
{
    public class RestaurantBL
    {
        public IEnumerable<SelectListItem> GetRestaurantNames()
        {
            return new RestaurantDAL().GetAllRestaurntNames();
        }
    }
}
