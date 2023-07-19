using MarketManager.Application.Common.JWT.Interfaces;
using MarketManager.Application.Common.JWT.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MarketManager.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddScoped<IUserRefreshToken,RefreshToken>();
        services.AddScoped<IJwtToken, JwtToken>();

        return services;
    }
}
