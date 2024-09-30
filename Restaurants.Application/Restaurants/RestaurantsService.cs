﻿using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Restaurants.Application.Restaurants
{
    public class RestaurantsService(IRestaurantsRepository restaurantsRepository, 
        ILogger<Restaurant> logger) : IRestaurantsService
    {
        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetById(int id)
        {
            logger.LogInformation("Getting restaurant by Id");
            var restaurant = await restaurantsRepository.GetByIdAsync(id);
            return restaurant;
        }
    }
}
