using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;

namespace Restaurant.Web.Controllers
{
    public class BillsController : Controller
    {
        // GET: Bills
        public ActionResult Bills()
        {
            OrderBL orderBL = new OrderBL();
            CustomerBL customerBL = new CustomerBL();

            BillsBO billsBO = new BillsBO();
            billsBO.CustomerNames = customerBL.GetCustomerNames();
            billsBO.OrderIDs = orderBL.GetOrderIDs();
            
            return View(billsBO);
          
        }
        [HttpPost]
        public ActionResult Bills(BillsBO billsBO)
        {
            if (ModelState.IsValid)
            {
                BillsBL billsBL  = new BillsBL();
                billsBL.AddBill(billsBO);
                return RedirectToAction("Bills");
            }
            OrderBL orderBL = new OrderBL();
            CustomerBL customerBL = new CustomerBL();

            billsBO = new BillsBO();
            billsBO.CustomerNames = customerBL.GetCustomerNames();
            billsBO.OrderIDs = orderBL.GetOrderIDs();
            ViewBag.Message ="Bills Generated Successfully";
            return View(billsBO);
        }
    }
}