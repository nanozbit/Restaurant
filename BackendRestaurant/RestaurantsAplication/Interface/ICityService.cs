
using RestaurantsAplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsAplication.Interface
{
    public interface ICityService 
    {
        public IEnumerable<CityViewModel> ListCity();
        public IEnumerable<CityViewModel> GetCity(int id);
        public void DeleteCity(int IdRestaurant);
        public void SaveCity(CityViewModel city);
        public void UpdateCity(CityViewModel city);
    }
}
