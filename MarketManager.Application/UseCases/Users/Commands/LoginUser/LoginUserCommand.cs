using MarketManager.Application.Common.JWT.Models;
using MediatR;

namespace MarketManager.Application.UseCases.Users.Commands.LoginUser;
public class LoginUserCommand:IRequest<TokenResponse>
{
    public string Username { get; set; } 
    public string Password { get; set; }
}
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokenResponse>
{
    public Task<TokenResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
