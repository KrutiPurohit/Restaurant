using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace BusinessLogic
{
    public class BillsBL
    {
        public bool AddBill(BillsBO billsBO)
        {
            int result = 0;
            if ( billsBO!=null)
            { 
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Restaurant.USP_Bills_CRUDOperations", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@BillsID",0);
                sqlCommand.Parameters.AddWithValue("@OrderID", billsBO.OrderID);
                sqlCommand.Parameters.AddWithValue("@CustomerID",billsBO.CustomerID);
                sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.INSERT);
                result = sqlCommand.ExecuteNonQuery();
            }

            }
            if (result > 0)
                return true;
            else
                return false;
        }
        public BillSummaryBO GetBillSummary(int orderID)
        {
            BillSummaryBO billSummaryBO = new BillSummaryBO();

            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            string sqlSummary = "SELECT BL.OrderID,RS.RestaurantName,CS.CustomerName,MI.ItemName,MI.ItemPrice,OD.ItemQuantity,OD.OrderAmount,OD.OrderDate, BL.BillsAmount FROM Restaurant.Bills AS BL INNER JOIN Restaurant.Restaurant AS RS ON BL.RestaurantID = RS.RestaurantID INNER JOIN Restaurant.Customer AS CS ON BL.CustomerID = CS.CustomerID INNER JOIN Restaurant.[Order] AS OD ON BL.OrderID = OD.OrderID INNER JOIN Restaurant.RestaurantMenuItem AS MI ON OD.MenuItemID = MI.MenuItemID WHERE BL.OrderID=" + orderID;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlSummary, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                sqlConnection.Open();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();

                billSummaryBO = (from DataRow dataRow in dataTable.Rows
                               select new BillSummaryBO()
                               {

                                   OrderID = Convert.ToString(dataRow["OrderID"]),
                                   RestaurantName= Convert.ToString(dataRow["RestaurantName"]),
                                   CustomerName = Convert.ToString(dataRow["CustomerName"]),
                                   ItemName = Convert.ToString(dataRow["ItemName"]),
                                   ItemPrice = Convert.ToString(dataRow["ItemPrice"]),
                                   ItemQuantity = Convert.ToString(dataRow["ItemQuantity"]),
                                   OrderAmount = Convert.ToString(dataRow["OrderAmount"]),
                                   BillAmount= Convert.ToString(dataRow["BillsAmount"]),
                                   OrderDate = Convert.ToString(dataRow["OrderDate"])
                               }).ToList().First();
                return billSummaryBO;
            }
        }
    }
}
