using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommand> logger,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restaurant with id {RestaurantId}", request.Id);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurant is null)
                throw new NotFoundException("Restaurant",request.Id.ToString());

            await restaurantsRepository.Delete(restaurant);
        }
    }
}
