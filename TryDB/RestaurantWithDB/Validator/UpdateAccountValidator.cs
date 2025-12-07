using FluentValidation;

public class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
{
    public UpdateAccountValidator()
    {
        RuleFor(item => item.Username)
            .Length(5, 15).WithMessage("Username must be between 5 and 15 characters!");

        RuleFor(item => item.EmailAddress)
            .EmailAddress().WithMessage("Email is not valid!");
            
        RuleFor(item => item.PhoneNumber)
            .MinimumLength(5).WithMessage("Phone number must have minimum 5 characters. Please enter a valid phone number!");
    }
}