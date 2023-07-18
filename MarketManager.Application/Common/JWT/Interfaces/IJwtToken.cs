using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MarketManager.Application.Common.JWT.Models;

namespace MarketManager.Application.Common.JWT.Interfaces;
public interface IJwtToken
{
    ValueTask<TokenResponse> CreateTokenAsync(string userName);
    ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    ValueTask<string> GenerateRefreshTokenAsync(string userName);
}
