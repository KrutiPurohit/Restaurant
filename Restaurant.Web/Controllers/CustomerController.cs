using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;

namespace Restaurant.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Customer()
        {
            RestaurantBL restaurantBL = new RestaurantBL();
            CustomerBO customerBO = new CustomerBO();
            customerBO.RestaurantNames = restaurantBL.GetRestaurantNames();
            return View(customerBO);
        }

        [HttpPost]
        public ActionResult Customer(CustomerBO customerBO)
        {
            if (ModelState.IsValid)
            {
                CustomerBL customerBL = new CustomerBL();
                CustomBO customBO = customerBL.AddCustomer(customerBO);
                TempData["AlertMessage"] = "New Customer Added Successfully ";
                return RedirectToAction("Customer");
            }
            RestaurantBL restaurantBL = new RestaurantBL();
            customerBO = new CustomerBO();
            customerBO.RestaurantNames = restaurantBL.GetRestaurantNames();
            return View(customerBO);
        }
    }
}