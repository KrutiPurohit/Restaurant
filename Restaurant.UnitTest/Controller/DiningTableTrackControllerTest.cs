using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Restaurant.Web;
using Restaurant.Web.Controllers;
using System.Web.Mvc;
using BusinessObjects;

namespace Restaurant.UnitTest.Controller
{
    [TestClass]
    public class DiningTableTrackControllerTest
    {
        [TestMethod]
        public void CustomerDiningTableTrack()
        {
            // Arrange
            DiningTableTrackController diningTableTrackController = new DiningTableTrackController();
            // Act
            ViewResult result = diningTableTrackController.DiningTableTrack() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
