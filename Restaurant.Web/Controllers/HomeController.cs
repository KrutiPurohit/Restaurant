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
            return View();
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
    }
}