using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.JWT.Interfaces;
using MarketManager.Application.Common.JWT.Models;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common.JWT.Service;
public class JwtToken : IJwtToken
{
    public ValueTask<TokenResponse> CreateTokenAsync(string userName,ICollection<Role> Roles, CancellationToken cancellationToken =default)
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
