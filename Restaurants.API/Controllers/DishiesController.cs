using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishies.Commands.CreateDish;

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
    }
}
