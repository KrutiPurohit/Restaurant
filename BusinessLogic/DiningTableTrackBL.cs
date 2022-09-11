using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessObjects;

namespace BusinessLogic
{
    public class DiningTableTrackBL
    {
        public string GetDiningTableStatus(int diningTableID)
        {
            return new DiningTableTrackDAL().GetDiningTableStatus(diningTableID);
        }
        public List<DiningTableTrackBO> GetAllDiningTableTrackDetails()
        {
            return new DiningTableTrackDAL().GetAllDiningTableTrackDetails();
        }
    }
}
