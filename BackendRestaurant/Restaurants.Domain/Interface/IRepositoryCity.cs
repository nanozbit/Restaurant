using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Interface
{
    public interface IRepositoryCity
    {
        public void AddCity(EntityCity city);
        public void DeleteCity(EntityCity city);

        public EntityCity GetCity(int id);
        public IQueryable<EntityCity> ListCities();
       
      
        public void UpdateCity(EntityCity city);
    }
}
