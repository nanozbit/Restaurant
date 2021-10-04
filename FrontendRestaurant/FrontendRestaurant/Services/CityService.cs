using FrontendRestaurant.Services.Interface;
using FrontendRestaurant.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FrontendRestaurant.Services
{
    public class CityService : ICityService
    {
        private readonly HttpClient _httpClient;
        public CityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> DeleteCity(int IdCity, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return await _httpClient.DeleteAsync($"api/City/{IdCity}");

        }

        public  async Task<IEnumerable<CityModel>> GetCity(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return await _httpClient.GetFromJsonAsync<CityModel[]>("api/City/"+id);

        }

        public async Task<IEnumerable<CityModel>> ListCity(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return await _httpClient.GetFromJsonAsync<CityModel[]>("api/City");
        }

        public async Task<HttpResponseMessage> SaveCity(CityModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return await _httpClient.PostAsJsonAsync<CityModel>("api/city", model);
        }

        public async Task<HttpResponseMessage> UpdateCity(CityModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return await _httpClient.PutAsJsonAsync<CityModel>("api/city", model);
        }
    }
}
