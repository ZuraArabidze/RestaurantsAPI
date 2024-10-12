using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using System.Reflection;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(GetAllRestaurantsQueryHandler).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));
            services.AddAutoMapper(applicationAssembly);
            services.AddValidatorsFromAssembly(applicationAssembly)
                    .AddFluentValidationAutoValidation();
        }
    }
}
