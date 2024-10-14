

using MediatR;
using Restaurants.Application.Dishies.Dtos;

namespace Restaurants.Application.Dishies.Queries.GetDisheByIdForRestaurant
{
    public class GetDishByIdForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishDto>
    {
        public int RestaurantId { get; } = restaurantId;
        public int DishId { get; } = dishId;
    }
}
