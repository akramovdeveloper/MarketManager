using FluentValidation;

namespace MarketManager.Application.UseCases.Users.Commands.RegisterUser;
public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>    
{
    public RegisterUserCommandValidator()
    {
        RuleFor(user => user.FullName).NotEmpty().WithMessage("Full name is required.");
        RuleFor(user => user.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(user => user.Phone).NotEmpty().WithMessage("Phone number is required.");
        RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required.");
        RuleFor(user => user.ConfirmPassword)
            .Equal(user => user.Password).WithMessage("Passwords do not match.");
    }
}
