using FluentValidation;

public class RegistrationValidator : AbstractValidator<RegisterRequest>
{
    public RegistrationValidator()
    {
        RuleFor(item => item.Email)
            .NotEmpty().WithMessage("Email can not be empty!")
            .EmailAddress().WithMessage("Email is not valid!");

        RuleFor(item => item.Username)
            .NotEmpty().WithMessage("Username can not be empty!")
            .Length(5, 15).WithMessage("Username must be between 5 and 15 characters!");
            
        RuleFor(item => item.Password)
            .NotEmpty().WithMessage("Password can not be empty!")
            .MinimumLength(6).WithMessage("Password must have minimum 6 characters!")
            .MaximumLength(50).WithMessage("Password must have maximum 50 characters!")
            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter!")
            .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter!")
            .Matches(@"[0-9]+").WithMessage("Password must contain at least one number!")
            .Matches(@"[\!\?\*\.]+").WithMessage("Password must contain at least one symbol (! ? * .)!");
    }
}