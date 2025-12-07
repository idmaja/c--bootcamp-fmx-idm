using System.Text.RegularExpressions;
using FluentValidation;

public class CreateRestaurantValidator : AbstractValidator<CreateRestaurantRequest>
{
    public CreateRestaurantValidator()
    {
        RuleFor(item => item.RestaurantName)
            .NotEmpty().WithMessage("Restaurant Name can not be empty!")
            .MaximumLength(100).WithMessage("Restaurant Name must have maximum 1000 characters!");

        RuleFor(item => item.RestaurantAddress)
            .NotEmpty().WithMessage("Restaurant Address must no be empty!")
            .MinimumLength(10).WithMessage("Restaurant Address is too short. Please enter a valid address!")
            .MaximumLength(255).WithMessage("Restaurant Address is too long. Please enter a valid address!");

        RuleFor(item => item.IsActive)
            .NotNull().WithMessage("IsActive Restaurant can not be null!");
    }
}