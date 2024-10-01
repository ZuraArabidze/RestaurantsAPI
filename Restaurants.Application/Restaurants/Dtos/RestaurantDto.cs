using Restaurants.Domain.Entities;
using Restaurants.Application.Dishies.Dtos;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string Description { get; set; } = default;
        public string Category { get; set; } = default;
        public bool hasDelivery { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public List<DishDto> Dishies { get; set; } = [];

        public static RestaurantDto FromEntity(Restaurant? restaurant)
        {
            if (restaurant == null)
            {
                return null;
            }
            return new RestaurantDto()
            {
                Category = restaurant.Category,
                Description = restaurant.Description,
                hasDelivery = restaurant.hasDelivery,
                Name = restaurant.Name,
                City = restaurant.Address?.City,
                Street = restaurant.Address?.Street,
                PostalCode = restaurant.Address?.PostalCode,
                Dishies = restaurant.Dishies.Select(DishDto.FromEntity).ToList()
            };

        }
    }
}
