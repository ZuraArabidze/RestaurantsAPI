﻿

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger ,
        IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand requset, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all restaurants");
            var restaurant = mapper.Map<Restaurant>(requset);
            int id = await restaurantsRepository.Create(restaurant);
            return id;
        }

    }
}
