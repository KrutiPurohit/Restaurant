using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;
using System.Collections.Generic;

namespace Restaurant.UnitTest.BusinessLogic
{
    [TestClass]
    public class CustomerBLTest
    {
        [TestMethod]
        public void AddCustomer()
        {
            // Arrange
            CustomerBO customerBO = new CustomerBO();
            customerBO.CustomerID = 0;
            customerBO.CustomerName = "Tarjana Purohit";
            customerBO.RestaurantID = 6;
            customerBO.MobileNo = "8545596566";

            CustomBO customBO = new CustomBO();

            // Act
            customBO = new CustomerBL().AddCustomer(customerBO);

            // Assert
            Assert.IsTrue(customBO.CustomMessageNumber>0);
        }

        [TestMethod]
        public void GetCustomerNames()
        {
            // Arrange
            IEnumerable<SelectListItem> customers;
            CustomerBL customerBL = new CustomerBL();
            // Act
            customers = customerBL.GetCustomerNames();
            // Assert
            Assert.IsTrue(customers!=null);
        }
    }
}
