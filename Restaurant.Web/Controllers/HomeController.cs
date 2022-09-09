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
                TempData["AlertMessage"] = "Order placed Successfully ";
                return RedirectToAction("Order");
            }
            RestaurantBL restaurantBL = new RestaurantBL();
            DiningTableBL diningTableBL = new DiningTableBL();
            MenuItemBL menuItemBL = new MenuItemBL();

             orderBO = new OrderBO();
            orderBO.RestaurantNames = restaurantBL.GetRestaurantNames();
            orderBO.DiningTableLocations = diningTableBL.GetDiningTableLocations();
            orderBO.MenuItemNames = menuItemBL.GetMenuItemNames();
            return View(orderBO);
        }

        [HttpGet]
        public JsonResult GetMenuItemPrice(int itemID)
        {
            MenuItemBL menuItemBL = new MenuItemBL();
            double itemPrice = menuItemBL.GetMenuITemPrice(itemID);
            return Json(itemPrice, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetDiningTableStatus(int diningTableID)
        {
            DiningTableTrackBL diningTableTrackBL = new DiningTableTrackBL();
            string diningTableStatus = diningTableTrackBL.GetDiningTableStatus(diningTableID);
            return Json(diningTableStatus, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetMenuItems(string restaurantID)
        {
            IEnumerable<SelectListItem> menuItemNames = new MenuItemBL().GetMenuItemNames(int.Parse(restaurantID));
            return Json(menuItemNames.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetDiningTableLocations(string restaurantID)
        {
            IEnumerable<SelectListItem> diningTableLocation = new DiningTableBL().GetDiningTableLocations(int.Parse(restaurantID));
            return Json(diningTableLocation.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}