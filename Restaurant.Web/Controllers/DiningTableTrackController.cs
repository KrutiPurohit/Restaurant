using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;

namespace Restaurant.Web.Controllers
{
    public class DiningTableTrackController : Controller
    {
        // GET: DiningTableTrack
        public ActionResult DiningTableTrack()
        {
            DiningTableTrackBL diningTableTrackBL = new DiningTableTrackBL();
            List<DiningTableTrackBO> diningTableTrackBOs = new List<DiningTableTrackBO>();
            diningTableTrackBOs = diningTableTrackBL.GetAllDiningTableTrackDetails();

            return View(diningTableTrackBOs);
        }
    }
}