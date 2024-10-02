using System.Collections;
using AutoMapper;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants
{
    public class RestaurantsService(IRestaurantsRepository restaurantsRepository, 
        ILogger<Restaurant> logger, IMapper mapper) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();
            var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return restaurantsDto!;
        }

        public async Task<RestaurantDto?> GetById(int id)
        {
            logger.LogInformation("Getting restaurant by Id");
            var restaurant = await restaurantsRepository.GetByIdAsync(id);
            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant); //RestaurantDto.FromEntity(restaurant);

            return restaurantDto;
        }

        public async Task<int> Create(CreateRestaurantDto dto)
        {
            logger.LogInformation("Creating a new restaurant");

            var restaurant = mapper.Map<Restaurant>(dto);
            int id = await restaurantsRepository.Create(restaurant);
            return id;
        }
    }
}
