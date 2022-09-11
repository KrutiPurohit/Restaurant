using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Web.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Restaurant()
        {
            //throw new HttpException(404,"Page Not Found");
            //throw new ArithmeticException();
            return View();
        }
    }
}