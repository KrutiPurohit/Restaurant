using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Restaurant.Web;
using Restaurant.Web.Controllers;
using System.Web.Mvc;
using BusinessObjects;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Restaurant.UnitTest.Controller
{
    [TestClass]
    public class CuisineControllerTest
    {
        [TestMethod]
        public void Cuisine()
        {
            // Arrange
            CuisineController controller = new CuisineController();
            // Act
            Task<ActionResult> result = controller.Cuisine() as Task<ActionResult>;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CuisineAdd()
        {
            // Arrange
            CuisineController controller = new CuisineController();
            // Act
            ViewResult result = controller.CuisineAdd() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        
    }
}
