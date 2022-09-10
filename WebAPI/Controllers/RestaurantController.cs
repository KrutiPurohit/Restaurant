using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic;
using BusinessObjects;

namespace WebAPI.Controllers
{
    public class RestaurantController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage PostRestaurant([FromBody] RestaurantBO restaurantBO)
        {
            RestaurantBL restaurantBL = new RestaurantBL();
            if (restaurantBL.AddRestaurant(restaurantBO))
                return Request.CreateResponse(HttpStatusCode.OK, "Restaurant is successfully added.");
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is some issue to add restaurant");
        }

        [HttpPut]
        public HttpResponseMessage UpdateRestaurant([FromBody] RestaurantBO restaurantBO)
        {
            RestaurantBL restaurantBL = new RestaurantBL();
            if (restaurantBL.UpdateRestaurant(restaurantBO))
                return Request.CreateResponse(HttpStatusCode.OK, "Restaurant is successfully updated.");
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is some issue to update restaurant");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteRestaurant([FromBody] RestaurantBO restaurantBO)
        {
            RestaurantBL restaurantBL = new RestaurantBL();
            if (restaurantBL.DeleteRestaurant(restaurantBO))
                return Request.CreateResponse(HttpStatusCode.OK, "Restaurant is successfully Deleted.");
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is some issue to delete restaurant");
        }
    }

}
