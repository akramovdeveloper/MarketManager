using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Users.Commands.LoginUser;
public class LoginUserCommandValidator:AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Username).NotEmpty().NotNull();
        RuleFor(x =>x.Password).NotEmpty().NotNull();
    }
}
