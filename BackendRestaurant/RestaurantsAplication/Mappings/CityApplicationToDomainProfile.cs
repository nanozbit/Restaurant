using AutoMapper;
using Restaurants.Domain.Entities;
using RestaurantsAplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantsAplication.Mappings
{
    public class CityApplicationToDomainProfile :Profile 
    {
        public CityApplicationToDomainProfile()
        {
            CreateMap<CityViewModel,EntityCity > ();
        }
    }
}
