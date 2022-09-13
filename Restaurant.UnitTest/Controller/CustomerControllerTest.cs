using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Restaurant.Web;
using Restaurant.Web.Controllers;
using System.Web.Mvc;
using BusinessObjects;

namespace Restaurant.UnitTest.Controller
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void Customer()
        {
            // Arrange
            CustomerController controller = new CustomerController();
            // Act
            ViewResult result = controller.Customer() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Customer(CustomerBO customerBO)
        {
            // Arrange
            CustomerController controller = new CustomerController();
            // Act
            ViewResult result = controller.Customer(customerBO) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
