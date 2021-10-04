using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsAplication.Interface;
using RestaurantsAplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet("token")]
        public IActionResult GetToken()
        {
            var token = _restaurantService.GetToken();
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_restaurantService.ListRestaurant());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetRestaurant(int id)
        {
            return Ok(_restaurantService.GetRestaurant(id));
        }

        [HttpPost]
        public IActionResult SaveRestaurant([FromBody] RestaurantViewModel restaurant)
        {
            if (restaurant == null)
            {
                return BadRequest();
            }

            if (restaurant.IdRestaurante == 0)
            {
                ModelState.AddModelError("Id", "ID_user can't be empty");
            }
            _restaurantService.SaveRestaurant(restaurant,"INSERT");
            return Created("Create new user", true);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            
            if (id == 0)
            {
                ModelState.AddModelError("Id", "ID_user can't be empty");
            }
            _restaurantService.DeleteRestaurant(id);
            return Created("Delete a user", true);
        }

        [HttpPut]
        public IActionResult Update(RestaurantViewModel restaurant)
        {
            if (restaurant == null)
            {
                return BadRequest();
            }

            if (restaurant.IdRestaurante == 0)
            {
                ModelState.AddModelError("Id", "ID_user can't be empty");
            }
            _restaurantService.SaveRestaurant(restaurant, "UPDATE");
            return Created("Create new user", true);
        }
    }
}
