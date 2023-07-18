using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.JWT.Interfaces;
using MarketManager.Application.Common.JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common.JWT.Service;
public class JwtToken : IJwtToken
{
    public ValueTask<TokenResponse> CreateTokenAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string> GenerateRefreshTokenAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }
}
