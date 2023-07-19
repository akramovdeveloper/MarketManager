using MarketManager.Application.Common.JWT.Interfaces;
using MarketManager.Application.UseCases.Users.Commands.LoginUser;
using MarketManager.Application.UseCases.Users.Response;
using MarketManager.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common.JWT.Service;
public class RefreshToken : IUserRefreshToken
{
    public ValueTask<UserRefreshToken> AddOrUpdateRefreshToken(UserRefreshToken refreshToken, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserResponse> AuthenAsync(LoginUserCommand user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteUserRefreshTokens(string username, string refreshToken, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserRefreshToken> GetSavedRefreshTokens(string username, string refreshtoken)
    {
        throw new NotImplementedException();
    }
}
