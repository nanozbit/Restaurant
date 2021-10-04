using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cityService.ListCity());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCity(int id)
        {
            return Ok(_cityService.GetCity(id));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            if (id == 0)
            {
                ModelState.AddModelError("Id", "ID_user can't be empty");
            }
            _cityService.DeleteCity(id);
            return Created("Delete a user", true);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CityViewModel request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            _cityService.SaveCity(request);
            return Created("Created a new user", true);
        }

        [HttpPut]
        public IActionResult Put([FromBody] CityViewModel request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            if (request.IdCiudad == 0)
            {
                ModelState.AddModelError("Id", "IdCiudad can't be empty");
            }
            _cityService.UpdateCity(request);
            return Created("Update a user", true);
        }

    }
}
