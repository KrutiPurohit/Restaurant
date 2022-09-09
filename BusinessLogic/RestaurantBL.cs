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
        public IEnumerable<SelectListItem> GetRestaurantNames()
        {
            return new RestaurantDAL().GetAllRestaurntNames();
        }
        public void AddRestaurant(RestaurantBO restaurantBO)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Restaurant.USP_Restaurant_CRUDOperations", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantID", 0);
                sqlCommand.Parameters.AddWithValue("@RestaurantName", restaurantBO.RestaurantName);
                sqlCommand.Parameters.AddWithValue("@Address", restaurantBO.Address);
                sqlCommand.Parameters.AddWithValue("@MobileNo", restaurantBO.MobileNo);
                sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.INSERT);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void UpdateRestaurant(RestaurantBO restaurantBO)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Restaurant.USP_Restaurant_CRUDOperations", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantID", restaurantBO.RestaurantID);
                sqlCommand.Parameters.AddWithValue("@RestaurantName", restaurantBO.RestaurantName);
                sqlCommand.Parameters.AddWithValue("@Address", restaurantBO.Address);
                sqlCommand.Parameters.AddWithValue("@MobileNo", restaurantBO.MobileNo);
                sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.UPDATE);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void DeleteRestaurant(RestaurantBO restaurantBO)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Restaurant.USP_Restaurant_CRUDOperations", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantID", restaurantBO.RestaurantID);
                sqlCommand.Parameters.AddWithValue("@RestaurantName", restaurantBO.RestaurantName);
                sqlCommand.Parameters.AddWithValue("@Address", restaurantBO.Address);
                sqlCommand.Parameters.AddWithValue("@MobileNo", restaurantBO.MobileNo);
                sqlCommand.Parameters.AddWithValue("@ActionType", ActionType.DELETE);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
