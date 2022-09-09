using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
    public class DiningTableTrackBL
    {
        public string GetDiningTableStatus(int diningTableID)
        {
            return new DiningTableTrackDAL().GetDiningTableStatus(diningTableID);
        }
    }
}
