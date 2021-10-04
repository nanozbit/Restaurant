using AutoMapper;
using AutoMapper.QueryableExtensions;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interface;
using RestaurantsAplication.Interface;
using RestaurantsAplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsAplication.Services
{
    
    public class CityService : ICityService
    {
        private IRepositoryCity _repositoryCity;
        private IMapper _mapper;
        public CityService(IRepositoryCity repositoryCity, IMapper mapper)
        {
            _repositoryCity = repositoryCity;
            _mapper = mapper;
        }

        public void DeleteCity(int IdCiudad)
        {
            var model = new CityViewModel()
            {
                IdCiudad = IdCiudad
            };
             var map = _mapper.Map<CityViewModel, EntityCity>(model);
            _repositoryCity.DeleteCity(map);
        }

        public IEnumerable<CityViewModel> GetCity(int id)
        {
            var listCity = new List<CityViewModel>();
            listCity.Add(_mapper.Map<CityViewModel>(_repositoryCity.GetCity(id)));
            
            return listCity;
           
        }

        public IEnumerable<CityViewModel> ListCity()
        {
            return _repositoryCity.ListCities().ProjectTo<CityViewModel>(_mapper.ConfigurationProvider);
        }

        public void SaveCity(CityViewModel city)
        {
           var cityEntity = _mapper.Map<CityViewModel, EntityCity>(city);
            _repositoryCity.AddCity(cityEntity);
        }

        public void UpdateCity(CityViewModel city)
        {
            var cityEntity = _mapper.Map<CityViewModel, EntityCity>(city);
            _repositoryCity.UpdateCity(cityEntity);
        }
    }
}
