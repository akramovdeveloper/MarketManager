using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace MarketManager.Application.Common.JWT;
public static class JwtConfiguration
{
    public static AuthenticationBuilder AddJwtSettings(this AuthenticationBuilder builder, IConfiguration configuration)
    {


        return builder;
    }
}