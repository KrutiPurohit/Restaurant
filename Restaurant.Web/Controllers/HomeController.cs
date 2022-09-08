using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObjects;
using BusinessLogic;

namespace Restaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Order()
        {
            RestaurantBL restaurantBL = new RestaurantBL();
            DiningTableBL diningTableBL = new DiningTableBL();
            MenuItemBL menuItemBL = new MenuItemBL();

            OrderBO orderBO = new OrderBO();
            orderBO.RestaurantNames = restaurantBL.GetRestaurantNames();
            orderBO.DiningTableLocations = diningTableBL.GetDiningTableLocations();
            orderBO.MenuItemNames = menuItemBL.GetMenuItemNames();

            return View(orderBO);
        }
        [HttpPost]
        public ActionResult Order(OrderBO orderBO)
        {
            if (ModelState.IsValid)
            {
                OrderBL orderBL = new OrderBL();
                CustomBO customBO = orderBL.AddOrder(orderBO);
                return RedirectToAction("Order");
            }
            return View(orderBO);
        }

        [HttpGet]
        public JsonResult GetMenuItemPrice(int itemID)
        {
            MenuItemBL menuItemBL = new MenuItemBL();
            double itemPrice = menuItemBL.GetMenuITemPrice(itemID);
            return Json(itemPrice, JsonRequestBehavior.AllowGet);

        }

    }
}