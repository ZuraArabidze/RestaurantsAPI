

using MediatR;
using Restaurants.Application.Dishies.Dtos;

namespace Restaurants.Application.Dishies.Queries.GetDishesForRestaurant
{
    public class GetDishesForRestaurantQuery : IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get; }

        public GetDishesForRestaurantQuery(int restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
