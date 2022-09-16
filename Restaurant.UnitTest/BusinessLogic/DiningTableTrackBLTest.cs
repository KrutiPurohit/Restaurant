using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;
using System.Collections.Generic;

namespace Restaurant.UnitTest.BusinessLogic
{
    [TestClass]
    public class DiningTableTrackBLTest
    {
        [TestMethod]
        public void GetDiningTableStatus()
        {
            // Arrange
            string tableStatus = string.Empty;
            DiningTableTrackBL diningTableTrackBL = new DiningTableTrackBL();
            int diningTableID;
            // Act
             diningTableID = 5;
            tableStatus = diningTableTrackBL.GetDiningTableStatus(diningTableID);
            string expectedStatus = "Vacant";
            // Assert
            Assert.AreEqual(expectedStatus, tableStatus);
        }
        [TestMethod]
        public void GetAllDiningTableTrackDetails()
        {
            // Arrange
            List<DiningTableTrackBO> tables;
            DiningTableTrackBL diningTableTrackBL = new DiningTableTrackBL();
            // Act
            tables = diningTableTrackBL.GetAllDiningTableTrackDetails();
            // Assert
            Assert.IsTrue(tables.Count>0);
        }
    }
}
