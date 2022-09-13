using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Restaurant.Web;
using Restaurant.Web.Controllers;
using System.Web.Mvc;
using BusinessObjects;

namespace Restaurant.UnitTest.Controller
{
    [TestClass]
    public class BillsControllerTest 
    {
        [TestMethod]
   
       public void Bills()
       {
       // Arrange
            BillsController controller = new BillsController();
        // Act
            ViewResult result = controller.Bills() as ViewResult;
       // Assert
           Assert.IsNotNull(result);
       }

        [TestMethod]
        public void Bills(BillsBO billsBo)
        {
            // Arrange
            BillsController controller = new BillsController();
            // Act
            ViewResult result = controller.Bills(billsBo) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

    }
}
