using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BusinessLogic;
using BusinessObjects;

namespace Restaurant.UnitTest.BusinessLogic
{
    [TestClass]
    public class RestaurantBLTest
    {
        [TestMethod]
        public void GetAllRestaurants()
        {
            // Arrange
            List<RestaurantBO> restaurantBOs = new List<RestaurantBO>();
            RestaurantBL restaurantBL = new RestaurantBL();
            // Act
            restaurantBOs = restaurantBL.GetAllRestaurants();
            // Assert
            Assert.IsTrue(restaurantBOs.Count > 0);
        }
      
        [TestMethod]
        public void AddRestaurant()
        {
            // Arrange
            RestaurantBO restaurantBO = new RestaurantBO();
            restaurantBO.RestaurantID = 0;
            restaurantBO.RestaurantName= "Mango";
            restaurantBO.Address = "303-complex,S.G.Highway,Ahmedabad";
            restaurantBO.MobileNo = "9656432321";
            RestaurantBL restaurantBL = new RestaurantBL();
            // Act
            bool inserted = restaurantBL.AddRestaurant(restaurantBO);
            // Assert
            Assert.IsTrue(inserted);
        }
        [TestMethod]
        public void UpdateRestaurant()
        {
            // Arrange
            RestaurantBO restaurantBO = new RestaurantBO();
            restaurantBO.RestaurantID = 7;
            restaurantBO.RestaurantName = "Mango";
            restaurantBO.Address = "3-Shivaji complex,S.G.Highway,Ahmedabad";
            restaurantBO.MobileNo = "9656432321";
            RestaurantBL restaurantBL = new RestaurantBL();
            // Act
            bool updated = restaurantBL.UpdateRestaurant(restaurantBO);
            // Assert
            Assert.IsTrue(updated);
        }

        [TestMethod]
        public void DeleteRestaurant()
        {
            // Arrange
            RestaurantBO restaurantBO = new RestaurantBO();
            restaurantBO.RestaurantID = 7;
            restaurantBO.RestaurantName = "";
            restaurantBO.Address = "";
            restaurantBO.MobileNo = "";
            RestaurantBL restaurantBL = new RestaurantBL();
            // Act
            bool deleted = restaurantBL.DeleteRestaurant(restaurantBO);
            // Assert
            Assert.IsTrue(deleted);
        }
    }
}
