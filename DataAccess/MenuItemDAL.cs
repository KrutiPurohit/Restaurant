using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess
{
    public class MenuItemDAL
    {
        RestaurantEntities restaurantEntities;
        public MenuItemDAL()
        {
            restaurantEntities = new RestaurantEntities();
        }
        public IEnumerable<SelectListItem> GetAllMenuItemNames()
        {
            IEnumerable<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in restaurantEntities.RestaurantMenuItems
                               select new SelectListItem()
                               {
                                   Text = obj.ItemName,
                                   Value = obj.MenuItemID.ToString(),
                                   Selected = true
                               }).ToList();
            return selectListItems;
        }
        public IEnumerable<SelectListItem> GetAllMenuItemNames(int restaurantID)
        {
            IEnumerable<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in restaurantEntities.RestaurantMenuItems
                               join cuisine in restaurantEntities.Cuisines
                               on obj.CuisineID equals cuisine.CuisineID
                               where cuisine.RestaurantID == restaurantID
                               select new SelectListItem()
                               {
                                   Text = obj.ItemName,
                                   Value = obj.MenuItemID.ToString(),
                                   Selected = true
                               }).ToList();
            return selectListItems;
        }
        public double GetItemPrice(int menuItemID)
        {
            double itemPrice = restaurantEntities.RestaurantMenuItems.Single(model => model.MenuItemID == menuItemID).ItemPrice.Value;
            return itemPrice;
        }
    }
}
