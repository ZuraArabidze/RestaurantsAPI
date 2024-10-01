﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishies.Dtos
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string Description { get; set; } = default;
        public double Price { get; set; }
        public int? KiloCalories { get; set; }
        public int RestaurantId { get; set; }

        public static DishDto FromEntity(Dish dish)
        {
            return new DishDto()
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                KiloCalories = dish.KiloCalories
            };
        }
    }
}
