using AutoMapper;
using Restaurants.Domain.Entities;
using RestaurantsAplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantsAplication.Mappings
{
    public class RestaurantDomainToApplicationProfile : Profile 
    {
        public RestaurantDomainToApplicationProfile()
        {
            CreateMap<RestaurantEntity, RestaurantViewModel>()
           //.ForMember(dest => dest.IdCiudad,
           // opt => opt.MapFrom(src => src.Ciudad.IdCiudad))
           .ForMember(dest => dest.IdRestaurante,
            opt => opt.MapFrom(src => src.IdRestaurante))
            .ForMember(dest => dest.NombreRestaurante,
            opt => opt.MapFrom(src => src.NombreRestaurante))
            .ForMember(dest => dest.NumeroAforo,
            opt => opt.MapFrom(src => src.NumeroAforo))
            .ForMember(dest => dest.FechaCreacion,
            opt => opt.MapFrom(src => src.FechaCreacion)); 
        }
    }
}
