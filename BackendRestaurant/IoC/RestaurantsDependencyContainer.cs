using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;
using Restaurants.Domain.Interface;
using RestaurantsAplication.Interface;
using RestaurantsAplication.Mappings;
using RestaurantsAplication.Services;

namespace IoC
{
    public static class RestaurantsDependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IRepositoryCity, RepositoryCity>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IRestaurantRepository, RepositoryRestaurant>();
        }

        public static void RegisterServicesApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfiguration));
            MappingConfiguration.RegisterMappings();
        }
    }
}
