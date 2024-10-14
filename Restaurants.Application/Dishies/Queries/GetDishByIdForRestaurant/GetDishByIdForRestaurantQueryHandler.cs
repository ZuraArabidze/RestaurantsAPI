﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishies.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishies.Queries.GetDisheByIdForRestaurant
{
    public class GetDishByIdForRestaurantQueryHandler(ILogger<GetDishByIdForRestaurantQueryHandler> logger,
        IRestaurantsRepository restaurantsRepository, IMapper mapper) 
        : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dish : {DishId} for restaurant with id : {RestaurantId}",
                request.DishId,
                request.RestaurantId);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }
            var dish = restaurant.Dishies.FirstOrDefault(d => d.Id == request.DishId);
            if (dish == null)
            {
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            }
            var results = mapper.Map<DishDto>(dish);
            return results;
        }
    }
}
