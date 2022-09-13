using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;
using Restaurant.Web.Controllers;

namespace Restaurant.Web.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Restaurant()
        {
            //throw new HttpException(404,"Page Not Found");
            //throw new ArithmeticException();
            RestaurantBL restaurantBL = new RestaurantBL();
            List<RestaurantBO> restaurantBos = new List<RestaurantBO>();
            restaurantBos = restaurantBL.GetAllRestaurants();

            return View(restaurantBos);
        }
    }
}