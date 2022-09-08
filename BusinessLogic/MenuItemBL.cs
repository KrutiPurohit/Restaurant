using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Web.Mvc;

namespace BusinessLogic
{
    public class MenuItemBL
    {
        public IEnumerable<SelectListItem> GetMenuItemNames()
        {
            return new MenuItemDAL().GetAllMenuItemNames();
        }
        public double GetMenuITemPrice(int itemID)
        {
            return new MenuItemDAL().GetItemPrice(itemID);
        }
    }
}
