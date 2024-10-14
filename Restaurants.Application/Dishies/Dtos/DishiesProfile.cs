
using AutoMapper;
using Restaurants.Application.Dishies.Commands.CreateDish;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishies.Dtos
{
    public class DishiesProfile : Profile
    {
        public DishiesProfile()
        {
            CreateMap<CreateDishCommand, Dish>();
            CreateMap<Dish, DishDto>();
        }
    }
}
