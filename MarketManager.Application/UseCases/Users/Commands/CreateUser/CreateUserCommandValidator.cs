using FluentValidation;

namespace MarketManager.Application.UseCases.Users.Commands.CreateUser;
public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {

        RuleFor(user => user.FullName)
         .NotEmpty().WithMessage("Full Name is required.")
         .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(user => user.Username)
            .NotEmpty().WithMessage("should be not empty value")
            .MinimumLength(3)
            .MaximumLength(20);

        RuleFor(user => user.Phone)
            .NotEmpty().WithMessage("Phone is required.")
            .Matches(@"^\+998(33|9[0-9])\d{7}$")
                .WithMessage("Phone must be in the format of '+998 90 123 45 67'.");

        RuleFor(user => user.Password)
           .NotEmpty().WithMessage("Password is required.")
           .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
           .Matches(@"^\+998(33|9[0-9])\d{7}$")
               .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one digit.");
    }
}
