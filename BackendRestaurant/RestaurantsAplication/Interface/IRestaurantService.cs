using RestaurantsAplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsAplication.Interface
{
    public interface IRestaurantService
    {
        public List<TokenResponse> GetToken();

        public IEnumerable<RestaurantViewModel> ListRestaurant();
        public Task SaveRestaurant(RestaurantViewModel restaurant, string operacion);

        public Task DeleteRestaurant(int IdRestaurant);
        public IEnumerable<RestaurantViewModel> GetRestaurant(int id);
    }
}
