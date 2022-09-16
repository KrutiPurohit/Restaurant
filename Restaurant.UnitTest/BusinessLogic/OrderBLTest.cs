using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;
using System.Collections.Generic;

namespace Restaurant.UnitTest.BusinessLogic
{
    [TestClass]
    public class OrderBLTest
    {
        [TestMethod]
        public void GetOrderIDs()
        {
            // Arrange
            IEnumerable<SelectListItem> orders;
            OrderBL orderBL = new OrderBL();
            // Act
            orders = orderBL.GetOrderIDs();
            // Assert
            Assert.IsTrue(orders != null);
        }

        [TestMethod]
        public void AddOrder()
        {
            // Arrange
            OrderBO orderBO = new OrderBO();
            orderBO.OrderID = 0;
            orderBO.OrderDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            orderBO.RestaurantID = 4;
            orderBO.MenuItemID = 2;
            orderBO.ItemQuantiy = 2;
            orderBO.OrderAmount = 180;
            orderBO.DiningTableID = 6;


            CustomBO customBO = new CustomBO();

            // Act
            customBO = new OrderBL().AddOrder(orderBO);

            // Assert
            Assert.IsTrue(customBO.CustomMessageNumber > 0);
        }
    }
}
