using FrontendRestaurant.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontendRestaurant.Services.Interface
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<RestaurantModel>> ListRestaurant();
        public Task<IEnumerable<TokenModel>> GetToken();
        public Task<HttpResponseMessage> SaveRestaurant(RestaurantFormModel model);
        public Task<HttpResponseMessage> DeleteRestaurant(int IdRestaurant);
        public Task<HttpResponseMessage> UpdateRestaurant(RestaurantFormModel model);

    }
}
