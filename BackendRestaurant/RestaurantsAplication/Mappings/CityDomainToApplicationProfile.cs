using AutoMapper;
using Restaurants.Domain.Entities;
using RestaurantsAplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantsAplication.Mappings
{
    public class CityDomainToApplicationProfile : Profile
    {
        public CityDomainToApplicationProfile()
        {
            CreateMap<EntityCity, CityViewModel>();
        }
    }
}
