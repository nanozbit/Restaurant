using FrontendRestaurant.Services.Interface;
using FrontendRestaurant.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace FrontendRestaurant.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly HttpClient _httpClient;
        public RestaurantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public  async Task<HttpResponseMessage> DeleteRestaurant(int IdRestaurant)
        {
            return await _httpClient.DeleteAsync($"api/Restaurant/{IdRestaurant}");
        }

        public async Task<IEnumerable<TokenModel>> GetToken()
        {
            
            return await _httpClient.GetFromJsonAsync<TokenModel[]>("api/Restaurant/Token");
        }

        public async Task<IEnumerable<RestaurantModel>> ListRestaurant()
        {
            return await _httpClient.GetFromJsonAsync<RestaurantModel[]>("api/Restaurant");
        }

        public async Task<HttpResponseMessage> SaveRestaurant(RestaurantFormModel model)
        {
           return await _httpClient.PostAsJsonAsync<RestaurantFormModel>("api/Restaurant", model);
            
        }

        public  async Task<HttpResponseMessage> UpdateRestaurant(RestaurantFormModel model)
        {
            return await _httpClient.PutAsJsonAsync<RestaurantFormModel>("api/Restaurant",model);
        }
    }
}
