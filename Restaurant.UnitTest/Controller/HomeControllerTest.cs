using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Restaurant.Web;
using Restaurant.Web.Controllers;
using System.Web.Mvc;
using BusinessObjects;

namespace Restaurant.UnitTest.Controller
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Order()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Order() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        public void Order(OrderBO orderBo)
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Order(orderBo) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        public void GetMenuItemPrice(int itemID)
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            JsonResult result = controller.GetMenuItemPrice(itemID) as JsonResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
