using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Web.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Cuisine()
        {
            return View();
        }
    }
}