using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Mvc;


namespace BusinessLogic
{
    public class ReportBL
    {
        private readonly SqlConnection sqlConnection;
        private readonly string commandText = "Restaurant.USP_Dynamic_GetAllCustomerOrderDetails";

        public ReportBL()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ToString();
            sqlConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<SelectListItem> GetColumnNamesToFilter()
        {
            IEnumerable<SelectListItem> selectListItems = new List<SelectListItem>();

            string sqlQuery = "SELECT CS.CustomerName,ODR.OrderDate, RS.RestaurantName, DT.Location,ODR.OrderAmount FROM Restaurant.Bills AS BL INNER JOIN Restaurant.[Order] AS ODR ON BL.OrderID = ODR.OrderID INNER JOIN Restaurant.Customer AS CS ON BL.CustomerID = CS.CustomerID INNER JOIN Restaurant.DiningTable AS DT  ON ODR.DiningTableID = DT.DiningTableID INNER JOIN Restaurant.Restaurant AS RS ON BL.RestaurantID = RS.RestaurantID";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();


            selectListItems = (from DataColumn dataColumn in dataTable.Columns
                               select new SelectListItem()
                               {
                                   Text = dataColumn.ColumnName,
                                   Value = dataColumn.ColumnName,
                                   Selected = true
                               }).ToList();
            int count = 1;
            foreach (SelectListItem selectListItem in selectListItems)
            {
                if (count == 1)
                    selectListItem.Value = "CS." + selectListItem.Value;
                if(count==2 || count==5)
                    selectListItem.Value= "ODR." + selectListItem.Value;
                if (count == 3)
                    selectListItem.Value = "RS." + selectListItem.Value;
                if (count == 4)
                    selectListItem.Value = "DT." + selectListItem.Value;
                count++;
            }
            return selectListItems;
        }

        public List<ReportFilterBo> GetAllFilteredRecords(ReportBo reportBo)
        {
            string filterBy = string.Empty;
            string orderBy = string.Empty;

            if (reportBo.ColumnToFilter == "CS.CustomerName" || reportBo.ColumnToFilter == "RS.RestaurantName" || reportBo.ColumnToFilter == "DT.Location")
                filterBy = reportBo.ColumnToFilter +" "+ reportBo.Operator +"  '%"+ reportBo.FilterValue+"%'  ";
            else if (reportBo.ColumnToFilter == "ODR.OrderDate")
                filterBy = reportBo.ColumnToFilter + " " +reportBo.Operator + "  '" + Convert.ToDateTime(reportBo.FilterValue).ToString("yyy-MM-dd") + "'  ";
            else 
                filterBy = reportBo.ColumnToFilter + reportBo.Operator + reportBo.FilterValue;

            orderBy = reportBo.OrderByColumn + " " + reportBo.OrderByType;

            List<ReportFilterBo> reportFilterBOs = new List<ReportFilterBo>();

            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FilterBy",filterBy );
            sqlCommand.Parameters.AddWithValue("@OrderBy",orderBy);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();


            reportFilterBOs = (from DataRow dataRow in dataTable.Rows
                               select new ReportFilterBo()
                               {
                                   CustomerName = Convert.ToString(dataRow["CustomerName"]),
                                   Location = Convert.ToString(dataRow["Dining Table"]),
                                   RestaurantName = Convert.ToString(dataRow["RestaurantName"]),
                                   OrderAmount = Convert.ToString(dataRow["OrderAmount"]),
                                   OrderDate = Convert.ToDateTime(dataRow["Order Date"]).ToShortDateString()
                               }).ToList();
            return reportFilterBOs;
        }
    }
}
