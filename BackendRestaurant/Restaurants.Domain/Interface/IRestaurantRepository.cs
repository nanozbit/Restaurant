using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Interface
{
    public interface IRestaurantRepository
    {
        public List<RestaurantEntity> ListRestaurants();
        public Task AddRestaurant(RestaurantEntity restaurantEntity, string Operacion);
        public Task DeleteRestaurant(int IdRestaurant);

        public  Task UpdateRestaurant(RestaurantEntity restaurant);
        public IEnumerable<RestaurantEntity> GetRestaurant(int id);
    }
}
