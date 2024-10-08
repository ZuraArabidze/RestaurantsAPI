using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionServiceExtensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));

            services.AddAutoMapper(applicationAssembly);

            services.AddValidatorsFromAssemblies([applicationAssembly])
                .AddFluentValidationAutoValidation();
        }
    }
}
