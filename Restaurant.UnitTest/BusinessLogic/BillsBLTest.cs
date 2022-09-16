using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;
using BusinessObjects;

namespace Restaurant.UnitTest.BusinessLogic
{
    [TestClass]
    public class BillsBLTest
    {
        [TestMethod]
        public void AddBill()
        {
            // Arrange
            BillsBO billsBO = new BillsBO { CustomerID = 6, OrderID = 15 };
            BillsBL billsBL = new BillsBL();
            // Act
            bool inserted = billsBL.AddBill(billsBO);
            // Assert
            Assert.IsTrue(inserted);
        }
    }
}
