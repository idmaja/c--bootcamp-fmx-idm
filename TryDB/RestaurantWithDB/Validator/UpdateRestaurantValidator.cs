using System.Text.RegularExpressions;
using FluentValidation;

public class UpdateRestaurantValidator : AbstractValidator<UpdateRestaurantRequest>
{
    public UpdateRestaurantValidator()
    {
        RuleFor(item => item.RestaurantName)
            .MaximumLength(100).WithMessage("Restaurant Name must have maximum 1000 characters!");

        RuleFor(item => item.RestaurantAddress)
            .MinimumLength(10).WithMessage("Restaurant Address is too short. Please enter a valid address!")
            .MaximumLength(255).WithMessage("Restaurant Address is too long. Please enter a valid address!");
    }
}