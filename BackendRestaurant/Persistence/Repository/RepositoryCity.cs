using Persistence.Context;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepositoryCity : IRepositoryCity
    {
        private readonly SiberianContext _cityContext;
        public RepositoryCity(SiberianContext cityContext)
        {
            _cityContext = cityContext;
        }

        public void AddCity(EntityCity city)
        {
            _cityContext.Ciudad.Add(city);
            _cityContext.SaveChanges();
        }
     
        public  void DeleteCity(EntityCity city)
        {
            _cityContext.Ciudad.Remove(city);
            _cityContext.SaveChanges();
        }

        public EntityCity GetCity(int id)
        {
            return _cityContext.Ciudad.Find(id);
        }

        public IQueryable<EntityCity> ListCities()
        {
            return _cityContext.Ciudad;
        }

        public void UpdateCity(EntityCity city)
        {
            _cityContext.Ciudad.Update(city);
            _cityContext.SaveChanges();

        }

    }
}
