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
    public class CuisineController : ApiController
    {
        public CuisineController()
        {

        }

        [HttpGet]
        public HttpResponseMessage GetAllCuisines()
        {
            CuisineBL cuisineBL = new CuisineBL();
            return Request.CreateResponse(HttpStatusCode.OK, cuisineBL.GetAllCuisines());
        }

        [HttpGet]
        public HttpResponseMessage GetCuisineByID(int cuisineID)
        {
            CuisineBL cuisineBL = new CuisineBL();
            return Request.CreateResponse(HttpStatusCode.OK, cuisineBL.GetCuisineByID(cuisineID));
        }

        [HttpPost]
        public HttpResponseMessage PostCuisine([FromBody] CuisineBO cuisineBO)
        {
            CuisineBL cuisineBL = new CuisineBL();
          
            if(cuisineBL.AddCuisine(cuisineBO))
                return Request.CreateResponse(HttpStatusCode.OK, "Cuisine is successfully added.");
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is some issue to add cuisine");
        }
        [HttpPut]
        public HttpResponseMessage UpdateCuisine([FromBody] CuisineBO cuisineBO)
        {
            CuisineBL cuisineBL = new CuisineBL();
           
            if (cuisineBL.UpdateCuisine(cuisineBO))
                return Request.CreateResponse(HttpStatusCode.OK, "Cuisine is successfully updated.");
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is some issue to update cuisine");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteCuisine([FromUri]int cuisineID)
        {
            CuisineBL cuisineBL = new CuisineBL();
            CuisineBO cuisineBO = new CuisineBO();
            cuisineBO.CuisineID = cuisineID;
            cuisineBO.RestaurantID = 0;
            cuisineBO.CuisineName = "";
             if (cuisineBL.DeleteCuisine(cuisineBO))
                return Request.CreateResponse(HttpStatusCode.OK, "Cuisine is successfully deleted.");
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is some issue to delete cuisine");
        }

    }
}
