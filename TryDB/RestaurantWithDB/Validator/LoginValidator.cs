using System.Text.RegularExpressions;
using FluentValidation;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(item => item.Username)
            .NotEmpty().WithMessage("Username can not be empty!")
            .NotNull().WithMessage("Username can not be null!")
            .Must(value => Regex.IsMatch(value!, @"^[a-zA-Z0-9]+$")).WithMessage("Username must not contain symbols!");

        RuleFor(item => item.Password)
            .NotEmpty().WithMessage("Password can not be empty!")
            .NotNull().WithMessage("Password can not be null!");
    }
}