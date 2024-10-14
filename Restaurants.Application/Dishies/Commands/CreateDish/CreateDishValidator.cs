﻿
using FluentValidation;

namespace Restaurants.Application.Dishies.Commands.CreateDish
{
    public class CreateDishValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishValidator() 
        {
            RuleFor(dish => dish.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non-negative number.");

            RuleFor(dish => dish.KiloCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("KiloCalories must be a non-negative number.");
                
        }
    }
}
