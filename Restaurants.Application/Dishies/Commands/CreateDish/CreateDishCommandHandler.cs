
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Entities;
using AutoMapper;

namespace Restaurants.Application.Dishies.Commands.CreateDish
{
    public class CreateDishCommandHandler(ILogger<CreateDishCommand> logger, 
        IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository,
        IMapper mapper) : IRequestHandler<CreateDishCommand>
    {
        public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new dish: {@DishRequest}", request);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
            }
            var dish = mapper.Map<Dish>(request);
            await dishesRepository.Create(dish);
        }
    }
}
