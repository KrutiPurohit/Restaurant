using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;
using Restaurant.Web.Controllers;

namespace Restaurant.UnitTest.Controller
{
    [TestClass]
    public class ReportControllerTest
    {
        [TestMethod]
        public void Report()
        {
            // Arrange
            ReportController controller = new ReportController();
            // Act
            ViewResult result = controller.Report() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
