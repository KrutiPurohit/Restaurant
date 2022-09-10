using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccess;
using BusinessObjects;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BusinessLogic
{
    public class RestaurantBL
    {
        private readonly string commandText = "Restaurant.USP_Restaurant_CRUDOperations";
        public IEnumerable<SelectListItem> GetRestaurantNames()
        {
            return new RestaurantDAL().GetAllRestaurntNames();
        }
        public bool AddRestaurant(RestaurantBO restaurantBO)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
               
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantID", 0);
                sqlCommand.Parameters.AddWithValue("@RestaurantName", restaurantBO.RestaurantName);
                sqlCommand.Parameters.AddWithValue("@Address", restaurantBO.Address);
                sqlCommand.Parameters.AddWithValue("@MobileNo", restaurantBO.MobileNo);
                sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.INSERT);
                int result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (result >= 1)
                    return true;
                else
                    return false;
            }
        }
        public bool UpdateRestaurant(RestaurantBO restaurantBO)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
               
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantID", restaurantBO.RestaurantID);
                sqlCommand.Parameters.AddWithValue("@RestaurantName", restaurantBO.RestaurantName);
                sqlCommand.Parameters.AddWithValue("@Address", restaurantBO.Address);
                sqlCommand.Parameters.AddWithValue("@MobileNo", restaurantBO.MobileNo);
                sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.UPDATE);
                int result=sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (result >= 1)
                    return true;
                else
                    return false;
            }
        }
        public bool DeleteRestaurant(RestaurantBO restaurantBO)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantID", restaurantBO.RestaurantID);
                sqlCommand.Parameters.AddWithValue("@RestaurantName", restaurantBO.RestaurantName);
                sqlCommand.Parameters.AddWithValue("@Address", restaurantBO.Address);
                sqlCommand.Parameters.AddWithValue("@MobileNo", restaurantBO.MobileNo);
                sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.DELETE);
                int result=sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (result >= 1)
                    return true;
                else
                    return false;
            }
        }
    }
}
