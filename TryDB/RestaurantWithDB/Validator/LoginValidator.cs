using System.Text.RegularExpressions;
using FluentValidation;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(item => item.Username)
            .NotEmpty().WithMessage("Username can not be empty!")
            .Must(value => !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^[a-zA-Z0-9]+$"))
                .WithMessage("Username can only contain letters and numbers!");

        RuleFor(item => item.Password)
            .NotEmpty().WithMessage("Password can not be empty!")
            .MinimumLength(6).WithMessage("Password must have minimum 6 characters!");
    }
}