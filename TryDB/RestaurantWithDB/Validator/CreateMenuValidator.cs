using System.Text.RegularExpressions;
using FluentValidation;

public class CreateMenuValidator : AbstractValidator<CreateMenuRequest>
{
    public CreateMenuValidator()
    {
        RuleFor(item => item.Name)
            .NotEmpty().WithMessage("Menu Name can not be empty!")
            .MaximumLength(100).WithMessage("Menu Name must have maximum 1000 characters!");

        RuleFor(item => item.Description)
            .MaximumLength(1000).WithMessage("Menu Description must have maximum 1000 characters!");

        RuleFor(item => item.Stock)
            .NotNull().WithMessage("Stock of the Menu can not be null!")
            .GreaterThanOrEqualTo(0).WithMessage("Stock of the Menu must be a valid number!");

        RuleFor(item => item.Price)
            .NotNull().WithMessage("Price of the Menu can not be null!")
            .GreaterThan(0).WithMessage("Price of the Menu must be a valid number!")
            .PrecisionScale(18, 2, true).WithMessage("Price cannot have more than 2 decimal places.");

        RuleFor(item => item.IsActive)
            .NotNull().WithMessage("IsActive Menu can not be null!");
    }
}