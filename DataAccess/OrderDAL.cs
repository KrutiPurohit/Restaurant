using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Web.Mvc;

namespace DataAccess
{
    public class OrderDAL
    {
        RestaurantEntities restaurantEntities;
        public OrderDAL()
        {
            restaurantEntities = new RestaurantEntities();
        }
        public CustomBO AddOrder(OrderBO orderBO)
        {
            CustomBO customBO = new CustomBO();
                Order order = new Order()
                {
                     OrderDate = orderBO.OrderDate,
                     RestaurantID=orderBO.RestaurantID,
                     MenuItemID=orderBO.MenuItemID,
                     ItemQuantity=orderBO.ItemQuantiy,
                     OrderAmount=orderBO.OrderAmount,
                     DiningTableID=orderBO.DiningTableID
                };
            restaurantEntities.Orders.Add(order);
            int returnValue = restaurantEntities.SaveChanges();
            if (returnValue > 0)
            {
                DiningTableTrackDAL diningTableTrackDAL = new DiningTableTrackDAL();
                diningTableTrackDAL.UpdateDiningTableStatus(orderBO.DiningTableID);
                customBO.CustomMessage = "Data Successfully Added";
                customBO.CustomMessageNumber = returnValue;
            }
            else
            {
                customBO.CustomMessage = "There is some problem to add order";
                customBO.CustomMessageNumber = returnValue;
            }
            return customBO;
        }
        public IEnumerable<SelectListItem> GetAllOrderID()
        {
            IEnumerable<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in restaurantEntities.Orders
                                where !(from bills in restaurantEntities.Bills select bills.OrderID).Contains (obj.OrderID)
                               select new SelectListItem()
                               {
                                   Text = obj.OrderID.ToString(),
                                   Value = obj.OrderID.ToString(),
                                   Selected = true
                               }).ToList();
            return selectListItems;
        }
    }
}                                      
