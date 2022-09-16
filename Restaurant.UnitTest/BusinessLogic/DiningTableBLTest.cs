using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;
using System.Collections.Generic;

namespace Restaurant.UnitTest.BusinessLogic
{
    [TestClass]
    public class DiningTableBLTest
    {
        [TestMethod]
        public void GetDiningTableLocations()
        {
            // Arrange
            IEnumerable<SelectListItem> tables;
            DiningTableBL diningTableBL = new DiningTableBL();
            // Act
            tables = diningTableBL.GetDiningTableLocations();
            // Assert
            Assert.IsTrue(tables  != null);
        }
        [TestMethod]
        public void GetDiningTableLocations(int RestaurantID)
        {
            // Arrange
            IEnumerable<SelectListItem> tables;
            DiningTableBL diningTableBL = new DiningTableBL();
            // Act
            RestaurantID = 5;
            tables = diningTableBL.GetDiningTableLocations(RestaurantID);
            // Assert
            Assert.IsTrue(tables != null);
        }
    }
}
