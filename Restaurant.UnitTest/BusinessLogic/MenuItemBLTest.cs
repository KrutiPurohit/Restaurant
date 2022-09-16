using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObjects;
using System.Collections.Generic;

namespace Restaurant.UnitTest.BusinessLogic
{
    [TestClass]
    public class MenuItemBLTest
    {
        [TestMethod]
        public void GetMenuItemNames()
        {
            // Arrange
            IEnumerable<SelectListItem> menuItems;
            MenuItemBL menuItemBL = new MenuItemBL();
            // Act
            menuItems = menuItemBL.GetMenuItemNames();
           
            // Assert
            Assert.IsTrue(menuItems!=null);
        }
        [TestMethod]
        public void GetMenuItemNames(int restaurantID)
        {
            // Arrange
            IEnumerable<SelectListItem> menuItems;
            MenuItemBL menuItemBL = new MenuItemBL();
            // Act
            menuItems = menuItemBL.GetMenuItemNames(restaurantID);

            // Assert
            Assert.IsTrue(menuItems != null);
        }
        [TestMethod]
        public void GetItemPrice()
        {
            // Arrange
            int itemID;
            double expectedPrice=150;
            MenuItemBL menuItemBL = new MenuItemBL();
            // Act
            itemID = 9;
            double itemPrice = menuItemBL.GetMenuITemPrice(itemID);

            // Assert
            Assert.AreEqual(expectedPrice, itemPrice);
        }
    }
}
