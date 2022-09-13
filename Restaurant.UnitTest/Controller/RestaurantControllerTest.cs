using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Restaurant.Web;
using Restaurant.Web.Controllers;
using System.Web.Mvc;
using BusinessObjects;

namespace Restaurant.UnitTest.Controller
{
    [TestClass]
    public class RestaurantControllerTest
    {
        [TestMethod]
        public void Restaurant()
        {
            // Arrange
            RestaurantController controller= new RestaurantController();
            // Act
            ViewResult result = controller.Restaurant() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
