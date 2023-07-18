using FluentValidation;

namespace MarketManager.Application.UseCases.Users.Commands.DeleteUser;
public class DeleteUserCommandValidator:AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
