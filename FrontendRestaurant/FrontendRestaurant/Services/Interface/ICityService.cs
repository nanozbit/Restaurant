using FrontendRestaurant.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontendRestaurant.Services.Interface
{
    public interface ICityService
    {
        public Task <IEnumerable<CityModel>> ListCity(string token );
        public Task<IEnumerable<CityModel>> GetCity(int id, string token);
        public Task<HttpResponseMessage> SaveCity(CityModel model, string token);

        public Task<HttpResponseMessage> UpdateCity(CityModel model, string token);

        public Task<HttpResponseMessage> DeleteCity(int IdRestaurant, string token);

    }
}
