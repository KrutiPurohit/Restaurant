using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BusinessLogic;
using BusinessObjects;

namespace Restaurant.UnitTest.BusinessLogic
{
    [TestClass]
    public class CuisineBLTest
    {
        [TestMethod]
        public void GetAllCuisines()
        {
            // Arrange
            List<CuisineBO> cuisionBOs = new List<CuisineBO>();
            CuisineBL cuisineBL = new CuisineBL();
            // Act
            cuisionBOs = cuisineBL.GetAllCuisines();
            // Assert
            Assert.IsTrue(cuisionBOs.Count>0);
        }
        [TestMethod]
        public void GetCuisineByID()
        {
            // Arrange
            CuisineBO cuisionBO = new CuisineBO();
            CuisineBL cuisineBL = new CuisineBL();
            // Act
            cuisionBO = cuisineBL.GetCuisineByID(2);
            // Assert
            Assert.IsTrue(cuisionBO.CuisineID==2);
        }

        [TestMethod]
        public void AddCuisine()
        {
            // Arrange
            CuisineBO cuisionBO = new CuisineBO();
            cuisionBO.CuisineID = 0;
            cuisionBO.CuisineName = "Mexican";
            cuisionBO.RestaurantID = 6;
            CuisineBL cuisineBL = new CuisineBL();
            // Act
            bool inserted=cuisineBL.AddCuisine(cuisionBO);
            // Assert
            Assert.IsTrue(inserted);
        }
        [TestMethod]
        public void UpdateCuisine()
        {
            // Arrange
            CuisineBO cuisionBO = new CuisineBO();
            cuisionBO.CuisineID = 8;
            cuisionBO.CuisineName = "Mexican";
            cuisionBO.RestaurantID = 6;
            CuisineBL cuisineBL = new CuisineBL();
            // Act
            bool updated = cuisineBL.UpdateCuisine(cuisionBO);
            // Assert
            Assert.IsTrue(updated);
        }

        [TestMethod]
        public void DeleteCuisine()
        {
            // Arrange
            CuisineBO cuisionBO = new CuisineBO();
            cuisionBO.CuisineID = 8;
            cuisionBO.CuisineName = "";
            cuisionBO.RestaurantID = 0;
            CuisineBL cuisineBL = new CuisineBL();
            // Act
            bool deleted = cuisineBL.DeleteCuisine(cuisionBO);
            // Assert
            Assert.IsTrue(deleted);
        }
    }
}
