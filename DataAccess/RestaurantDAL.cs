using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BusinessObjects;
using System.Web.Mvc;

namespace DataAccess
{
    public class RestaurantDAL
    {
        RestaurantEntities restaurantEntities;
        public RestaurantDAL()
        {
            restaurantEntities = new RestaurantEntities();
        }
        public IEnumerable<SelectListItem> GetAllRestaurntNames()
        {
            IEnumerable<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in restaurantEntities.Restaurants
                               select new SelectListItem()
                               {
                                   Text = obj.RestaurantName,
                                   Value = obj.RestaurantID.ToString(),
                                   Selected = true
                               }).ToList();
            return selectListItems;
        }

    }
}
