using Restaurants.Application.Restaurants;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Dtos;


namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantsService.GetAllRestaurants();

            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = restaurantsService.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestautrant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/
            int id = await restaurantsService.Create(createRestaurantDto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
