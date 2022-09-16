using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BusinessLogic;
using BusinessObjects;
using System.Web.Mvc;

namespace Restaurant.UnitTest.BusinessLogic
{
    [TestClass]
    public class ReportBLTest
    {
        [TestMethod]
        public void GetColumnNamesToFilter()
        {
            // Arrange
            IEnumerable<SelectListItem> columns;
            ReportBL reportBL = new ReportBL();
            // Act
            columns = reportBL.GetColumnNamesToFilter();
            // Assert
            Assert.IsTrue(columns != null);
        }
        [TestMethod]
        public void GetAllFilteredRecords()
        {
            // Arrange
            List<ReportFilterBo> reportFilterBOs = new List<ReportFilterBo>();
            ReportBL reportBL = new ReportBL();
            ReportBo reportBo = new ReportBo();
            // Act
            reportBo.ColumnToFilter = "ODR.OrderAmount";
            reportBo.Operator = ">=";
            reportBo.FilterValue = "200";
            reportBo.OrderByColumn = "ODR.OrderAmount";
            reportBo.OrderByType = "DESC";
            reportFilterBOs = reportBL.GetAllFilteredRecords(reportBo);
            // Assert
            Assert.IsTrue(reportFilterBOs.Count > 0);
        }
    }
}
