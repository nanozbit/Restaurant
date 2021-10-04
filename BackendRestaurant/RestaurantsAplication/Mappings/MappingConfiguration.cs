using AutoMapper;


namespace RestaurantsAplication.Mappings
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CityDomainToApplicationProfile());
                cfg.AddProfile(new CityApplicationToDomainProfile());
                cfg.AddProfile(new RestaurantApplicationToDomainProfile());
                cfg.AddProfile(new RestaurantDomainToApplicationProfile());
            });
        }
    }
}
