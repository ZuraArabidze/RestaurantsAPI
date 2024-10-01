
using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishies.Dtos
{
    public class DishiesProfile : Profile
    {
        public DishiesProfile()
        {
            CreateMap<Dish, DishDto>();
        }
    }
}
