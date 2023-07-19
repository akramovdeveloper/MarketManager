using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MarketManager.Application.Common.JWT.Models;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;

namespace MarketManager.Application.Common.JWT.Interfaces;
public interface IJwtToken
{
    ValueTask<TokenResponse> CreateTokenAsync(string userName,ICollection<Role> roles,CancellationToken cancellationToken=default);
    ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    ValueTask<string> GenerateRefreshTokenAsync(string userName);
}
