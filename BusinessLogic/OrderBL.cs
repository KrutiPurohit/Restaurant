using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccess;
using System.Web.Mvc;

namespace BusinessLogic
{
    public class OrderBL
    {
        public CustomBO AddOrder(OrderBO orderBO)
        {
            return new OrderDAL().AddOrder(orderBO);
        }
        public IEnumerable<SelectListItem> GetOrderIDs()
        {
            return new OrderDAL().GetAllOrderID();
        }
    }
}
