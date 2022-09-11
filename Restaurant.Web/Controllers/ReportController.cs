using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;

namespace Restaurant.Web.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Report()
        {
            ReportBL reportBL = new ReportBL();
            ReportBo reportBo = new ReportBo();
            reportBo.ColumnNames = reportBL.GetColumnNamesToFilter();
            return View(reportBo);
        }

        [HttpPost]
        public ActionResult ReportShow(ReportBo reportBo)
        {
            ReportBL reportBL = new ReportBL();
            return View(reportBL.GetAllFilteredRecords(reportBo));
        }
    }
}