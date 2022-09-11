using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Web.Mvc;

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
        public List<DiningTableTrackBO> GetAllDiningTableTrackDetails()
        {
            List<DiningTableTrackBO> diningTableTrackBOs = new List<DiningTableTrackBO>();
            diningTableTrackBOs = (from obj in restaurantEntities.DiningTableTracks
                                   join dt in restaurantEntities.DiningTables
                                   on obj.DiningTableID equals dt.DiningTableID
                                   join rest in restaurantEntities.Restaurants
                                   on dt.RestaurantID equals rest.RestaurantID
                                   select new DiningTableTrackBO
                                   {
                                        DiningTableTrackID= obj.DiningTableTrackID,
                                       DiningTableID=  obj.DiningTableID,
                                       Location= dt.Location,
                                       TableStatus=obj.TableStatus, 
                                       RestaurantID=rest.RestaurantID,
                                       RestaurantName =rest.RestaurantName
                                   }).ToList();
            return diningTableTrackBOs;                    
        }
    }
}
