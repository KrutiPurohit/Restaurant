using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DiningTableTrackDAL
    {
        RestaurantEntities restaurantEntities;
        public DiningTableTrackDAL()
        {
            restaurantEntities = new RestaurantEntities();
        }
        public string GetDiningTableStatus(int diningTableID)
        {
            string tableStatus = restaurantEntities.DiningTableTracks.Single(Model=>Model.DiningTableID==diningTableID).TableStatus;
            return tableStatus;
        }
        public void UpdateDiningTableStatus(int diningTableID)
        {
          var status= restaurantEntities.DiningTableTracks.Single(Model => Model.DiningTableID == diningTableID);
            if (status != null)
            {
                status.TableStatus = "Occupied";
                restaurantEntities.SaveChanges();
            }

        }
    }
}
