using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants
{
    public class RestaurantsService(IRestaurantsRepository restaurantsRepository, 
        ILogger<Restaurant> logger) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();
            var restaurantsDto = restaurants.Select(RestaurantDto.FromEntity);

            return restaurantsDto!;
        }

        public async Task<RestaurantDto?> GetById(int id)
        {
            logger.LogInformation("Getting restaurant by Id");
            var restaurant = await restaurantsRepository.GetByIdAsync(id);
            var restaurantDto = RestaurantDto.FromEntity(restaurant);

            return restaurantDto;
        }
    }
}
