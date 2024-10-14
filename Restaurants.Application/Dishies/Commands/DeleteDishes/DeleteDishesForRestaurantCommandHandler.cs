
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishies.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository) 
        : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogWarning("Removing all dishies from restaurant : {RestaurantId}", request.RestaurantId);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }
            await dishesRepository.Delete(restaurant.Dishies);
        }
    }
}
