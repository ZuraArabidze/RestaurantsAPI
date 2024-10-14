
using MediatR;

namespace Restaurants.Application.Dishies.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommand : IRequest
    {
        public int RestaurantId { get; }
        public DeleteDishesForRestaurantCommand(int restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
