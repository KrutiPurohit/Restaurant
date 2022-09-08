using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess
{
    public class DiningTableDAL
    {
        RestaurantEntities restaurantEntities;
        public DiningTableDAL()
        {
            restaurantEntities = new RestaurantEntities();
        }
        public IEnumerable<SelectListItem> GetAllDiningTableLocations()
        {
            IEnumerable<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in restaurantEntities.DiningTables
                               select new SelectListItem()
                               {
                                   Text = obj.Location,
                                   Value = obj.DiningTableID.ToString(),
                                   Selected = true
                               }).ToList();
            return selectListItems;
        }
        public IEnumerable<SelectListItem> GetAllDiningTableLocations(int restaurantID)
        {
            IEnumerable<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in restaurantEntities.DiningTables
                               where obj.RestaurantID == restaurantID
                               select new SelectListItem()
                               {
                                   Text = obj.Location,
                                   Value = obj.DiningTableID.ToString(),
                                   Selected = true
                               }).ToList();
            return selectListItems;
        }
    }
}
