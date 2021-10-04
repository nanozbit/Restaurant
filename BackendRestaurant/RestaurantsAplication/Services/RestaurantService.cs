using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.IdentityModel.Tokens;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interface;
using RestaurantsAplication.Interface;
using RestaurantsAplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsAplication.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly string key = "This is my desfault Key to encrytion";
        private IRestaurantRepository _restaurantRepository;
        private IMapper _mapper;
        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public IEnumerable<RestaurantViewModel> ListRestaurant()
        {
            var result = _restaurantRepository.ListRestaurants().AsQueryable().ProjectTo<RestaurantViewModel>(_mapper.ConfigurationProvider);
            return result;
        }

        public List<TokenResponse> GetToken()
        {
            TokenResponse tokenResponse = new TokenResponse();
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, "guest")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            List<TokenResponse> TokenList = new List<TokenResponse>();

            tokenResponse.Token = tokenHandler.WriteToken(token);
            TokenList.Add(tokenResponse);
            return TokenList;
        }

        public async Task SaveRestaurant(RestaurantViewModel restaurant, string operacion)
        {
            var userEntity = _mapper.Map<RestaurantViewModel, RestaurantEntity>(restaurant);
            await _restaurantRepository.AddRestaurant(userEntity, operacion);
        }

        public async Task DeleteRestaurant(int IdRestaurant)
        {
            await _restaurantRepository.DeleteRestaurant(IdRestaurant);
        }

        public IEnumerable<RestaurantViewModel> GetRestaurant(int id)
        {
            var result =  _restaurantRepository.GetRestaurant(id).AsQueryable().ProjectTo<RestaurantViewModel>(_mapper.ConfigurationProvider);
            return result;
        }
    }
}
