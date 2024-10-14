using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishies.Commands.CreateDish;
using Restaurants.Application.Dishies.Dtos;
using Restaurants.Application.Dishies.Queries.GetDisheByIdForRestaurant;
using Restaurants.Application.Dishies.Queries.GetDishesForRestaurant;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurant/{restaurantId}/dishies")]
    [ApiController]
    public class DishiesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            await mediator.Send(command);
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId,dishId));
            return Ok(dish);
        }
    }
}
