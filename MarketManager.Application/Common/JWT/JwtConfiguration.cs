using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common.JWT;
public static class JwtConfiguration
{
    public static AuthenticationBuilder AddJwtSettings(this AuthenticationBuilder builder, IConfiguration configuration)
    {


        return builder;
    }
}