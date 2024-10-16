﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;

namespace Restaurants.Infrastructure.Extensions
{
    public static  class ServiceCollectionExtensions
    {
        public static void AddInfrastructre(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RestaurantsDb");
            services.AddDbContext<RestaurantsDbContext>(options =>
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());

            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.AddScoped<IDishesRepository, DishisRepository>();
        }
    }
}
