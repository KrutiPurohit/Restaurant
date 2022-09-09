using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Web.Mvc;

namespace DataAccess
{
    public class CustomerDAL
    {
        RestaurantEntities restaurantEntities;
        public CustomerDAL()
        {
            restaurantEntities = new RestaurantEntities();
        }
        public CustomBO AddCustomer(CustomerBO customerBO)
        {
            CustomBO customBO = new CustomBO();
            Customer customer = new Customer()
            {
                CustomerID = customerBO.CustomerID,
                RestaurantID = customerBO.RestaurantID,
                CustomerName = customerBO.CustomerName,
                MobileNo = customerBO.MobileNo
            };
            restaurantEntities.Customers.Add(customer);
            int returnValue = restaurantEntities.SaveChanges();

            if (returnValue > 0)
            {
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
        public IEnumerable<SelectListItem> GetAllCustomerNames()
        {
            IEnumerable<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in restaurantEntities.Customers
                               select new SelectListItem()
                               {
                                   Text = obj.CustomerName,
                                   Value = obj.CustomerID.ToString(),
                                   Selected = true
                               }).ToList();
            return selectListItems;
        }
    }
}
