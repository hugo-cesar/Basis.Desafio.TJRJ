using Basis.Desafio.TJRJ.Infra.CrossCutting;
using System.Net;
using System.Text.Json;

namespace Basis.Desafio.TJRJ.Api;

public class ErrorMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var errors = new List<string>();
        HttpStatusCode statusCode;

        if (exception is AppException appException)
        {
            errors.AddRange(appException.Errors);
            statusCode = HttpStatusCode.BadRequest;
        }
        else
        {
            errors.Add(exception.Message);
            statusCode = HttpStatusCode.InternalServerError;
        }

        var response = new
        {
            errors,
            status = statusCode
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}

public static class ErrorMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder) 
        => builder.UseMiddleware<ErrorMiddleware>();
}