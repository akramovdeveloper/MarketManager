using MarketManager.Application.Common.Exceptions;
using MarketManager.Application.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.API.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
           => (_next) = (next);



    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }

        catch (NotFoundException ex)
        {

            await HandleException(httpContext, ex, HttpStatusCode.NotFound, ex.Message);
        }
        catch(AlreadyExistsException ex)
        {
            await HandleException(httpContext, ex, HttpStatusCode.Conflict, ex.Message);
        }
        catch(UnauthorizedException ex)
        {
            await HandleException(httpContext, ex, HttpStatusCode.Unauthorized, ex.Message);
        }
        catch(ValidationException ex)
        {
            await HandleException(httpContext, ex, HttpStatusCode.BadRequest, ex.Message);
        }

        catch (Exception ex)
        {
            await HandleException(httpContext, ex, HttpStatusCode.InternalServerError, ex.Message);
        }

    }


    public async ValueTask<ActionResult> HandleException<TException>(HttpContext httpContext, TException ex, HttpStatusCode httpStatusCode, string message)
    {

        Log.Error("EXCEPTION:🔴 CLIENT_IP:{ClientIp}  CLIENT:{ERROR} " + $"\nDatetime:{DateTime.Now} | Message:{message} | Path:{httpContext.Request.Path}");
        HttpResponse response = httpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)httpStatusCode;

        ResponseCore<TException> error = new()
        {
            Errors = new string[] { message },
            StatusCode = httpStatusCode,
            IsSuccess = false,
            Result = ex
        };

        return await Task.FromResult(new BadRequestObjectResult(error));

    }
}


public static class GlobalExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionMiddleware>();
    }
}
