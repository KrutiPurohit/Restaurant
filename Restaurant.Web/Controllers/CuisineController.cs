using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using BusinessObjects;
using Newtonsoft.Json;
using BusinessLogic;

namespace Restaurant.Web.Controllers
{
    public class CuisineController : Controller
    {
        private static string WebAPIURL= "https://localhost:44360/";
    
        // GET: Cuisine
        public async Task<ActionResult> Cuisine()
        {
            List<CuisineBO> listOfCuisine = new List<CuisineBO>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(WebAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMessage = await client.GetAsync("Cuisine/GetAllCuisines");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cuisineList = responseMessage.Content.ReadAsStringAsync().Result;
                    listOfCuisine = JsonConvert.DeserializeObject<List<CuisineBO>>(cuisineList);
                }
            }
         
            
            return View(listOfCuisine);
        }

        public async Task<ActionResult> CuisineEdit(int cuisineID)
        {
            CuisineBO cuisineBO = new CuisineBO();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(WebAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMessage = await client.GetAsync("Cuisine/GetCuisineByID?cuisineID=" +cuisineID);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cuisine = responseMessage.Content.ReadAsStringAsync().Result;
                    cuisineBO = JsonConvert.DeserializeObject<CuisineBO>(cuisine);
                }
            }
            RestaurantBL restaurantBL = new RestaurantBL();
            cuisineBO.RestaurantNames = restaurantBL.GetRestaurantNames().ToList();
            return View(cuisineBO);
        }

        [HttpGet]
        public ActionResult CuisineAdd()
        {
            RestaurantBL restaurantBL = new RestaurantBL();
            CuisineBO cuisineBO = new CuisineBO();
             cuisineBO.RestaurantNames = restaurantBL.GetRestaurantNames().ToList();
            return View(cuisineBO);
        }

        [HttpPost]
        public async Task<ActionResult> CuisineAdd(CuisineBO cuisineBO)
        {
            string customMessage=string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(WebAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMessage = await client.PostAsJsonAsync("Cuisine/PostCuisine",cuisineBO);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cuisine = responseMessage.Content.ReadAsStringAsync().Result;
                    customMessage = JsonConvert.DeserializeObject<string>(cuisine);
                }
            }
            return RedirectToAction("Cuisine");
        }

        [HttpPost]
        public async Task<ActionResult> CuisineUpdate(CuisineBO cuisineBO)
        {
            string customMessage = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(WebAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMessage = await client.PutAsJsonAsync("Cuisine/UpdateCuisine", cuisineBO);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cuisine = responseMessage.Content.ReadAsStringAsync().Result;
                    customMessage = JsonConvert.DeserializeObject<string>(cuisine);
                }
            }
            return RedirectToAction("Cuisine");
        }

        [HttpGet]
        public async Task<ActionResult> CuisineDelete(CuisineBO cuisineBO)
        {
            string customMessage = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(WebAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMessage = await client.DeleteAsync("Cuisine/DeleteCuisine?cuisineID="+ cuisineBO.CuisineID);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cuisine = responseMessage.Content.ReadAsStringAsync().Result;
                    customMessage = JsonConvert.DeserializeObject<string>(cuisine);
                }
            }
            return RedirectToAction("Cuisine");
        }
    }
}