using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.JWT.Interfaces;
using MarketManager.Application.Common.JWT.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Users.Commands.LoginUser;
public class LoginUserCommand:IRequest<TokenResponse>
{
    public string Username { get; set; } 
    public string Password { get; set; }
}
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokenResponse>
{
    private readonly IJwtToken _jwtToken;
    private readonly IUserRefreshToken _userRefreshToken;
  
    public LoginUserCommandHandler(IJwtToken jwtToken, IUserRefreshToken userRefreshToken)
    {
        _jwtToken = jwtToken;
        _userRefreshToken = userRefreshToken;
       
    }

    public async Task<TokenResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var authenUser =await _userRefreshToken.AuthenAsync(request);
        if (authenUser is null) 
            throw new UnauthorizedException(request.Username,request.Password);

        var tokenResponse = await _jwtToken.CreateTokenAsync(authenUser.Username, authenUser.Roles,cancellationToken); 

        return tokenResponse;
    }
}
