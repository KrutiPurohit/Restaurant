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
    }
}
