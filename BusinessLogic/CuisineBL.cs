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

namespace BusinessLogic
{
    public class CuisineBL
    {
        private readonly SqlConnection sqlConnection;
        private readonly string commandText = "Restaurant.USP_Cuisine_CRUDOperations";
        public CuisineBL()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ToString();
            sqlConnection = new SqlConnection(connectionString);
        }
        
        public List<CuisineBO> GetAllCuisines()
        {
            List<CuisineBO> cuisionBOs = new List<CuisineBO>();

            string sqlQuery = "SELECT CS.CuisineID,CS.RestaurantID,CS.CuisineName,RS.RestaurantName FROM Restaurant.Cuisine AS CS INNER JOIN Restaurant.Restaurant AS RS ON CS.RestaurantID=RS.RestaurantID";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();


            cuisionBOs = (from DataRow dataRow in dataTable.Rows
                           select new CuisineBO()
                           {
                               CuisineID = Convert.ToInt32(dataRow["CuisineID"]),
                               RestaurantID = Convert.ToInt32(dataRow["RestaurantID"]),
                               RestaurantName = Convert.ToString(dataRow["RestaurantName"]),
                               CuisineName = Convert.ToString(dataRow["CuisineName"])
                           }).ToList();           
            return cuisionBOs;
        }
        public CuisineBO GetCuisineByID(int cuisineID)
        {
            CuisineBO cuisionBO = new CuisineBO();

            string sqlQuery = "SELECT CS.CuisineID,CS.RestaurantID,CS.CuisineName,RS.RestaurantName FROM Restaurant.Cuisine AS CS INNER JOIN Restaurant.Restaurant AS RS ON CS.RestaurantID=RS.RestaurantID WHERE CS.CuisineID=" + cuisineID;
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            cuisionBO = (from DataRow dataRow in dataTable.Rows
                         select new CuisineBO()
                         {
                             CuisineID = Convert.ToInt32(dataRow["CuisineID"]),
                             RestaurantID = Convert.ToInt32(dataRow["RestaurantID"]),
                             RestaurantName = Convert.ToString(dataRow["RestaurantName"]),
                             CuisineName = Convert.ToString(dataRow["CuisineName"])
                         }).Single();
            return cuisionBO;
        }

        public bool AddCuisine(CuisineBO cuisineBO)
        {
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CuisineID", cuisineBO.CuisineID);
            sqlCommand.Parameters.AddWithValue("@RestaurantID", cuisineBO.RestaurantID);
            sqlCommand.Parameters.AddWithValue("@CuisineName", cuisineBO.CuisineName);
            sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.INSERT);
            sqlConnection.Open();
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (result >= 1)
                return true;
            else
                return false;

        }

        public bool UpdateCuisine(CuisineBO cuisineBO)
        {
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CuisineID", cuisineBO.CuisineID);
            sqlCommand.Parameters.AddWithValue("@RestaurantID", cuisineBO.RestaurantID);
            sqlCommand.Parameters.AddWithValue("@CuisineName", cuisineBO.CuisineName);
            sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.UPDATE);
            sqlConnection.Open();
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (result >= 1)
                return true;
            else
                return false;

        }

        public bool DeleteCuisine(CuisineBO cuisineBO)
        {
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CuisineID", cuisineBO.CuisineID);
            sqlCommand.Parameters.AddWithValue("@RestaurantID", cuisineBO.RestaurantID);
            sqlCommand.Parameters.AddWithValue("@CuisineName", cuisineBO.CuisineName);
            sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.DELETE);
            sqlConnection.Open();
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (result >= 1)
                return true;
            else
                return false;

        }
    }
}
