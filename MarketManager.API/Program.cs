
using MarketManager.API.Middlewares;
using MarketManager.Application;
using MarketManager.Infrastructure;

namespace MarketManager.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApi();

        var app = builder.Build();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseGlobalExceptionMiddleware();

        app.UseAuthorization();

        
        app.MapControllers();

        app.Run();
    }
}