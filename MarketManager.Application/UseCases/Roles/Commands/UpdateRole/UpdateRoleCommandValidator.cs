using FluentValidation;

namespace MarketManager.Application.UseCases.Roles.Commands.UpdateRole;
public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3)
            .MaximumLength(100);
    }
}
