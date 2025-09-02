using FluentValidation;
using System.Text.Json;

namespace Mukhametshin_Test_Aviakod.Middlewares;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var json = JsonSerializer.Serialize(new { Error = string.Join('\n', ex.Errors.Select(x => x.ErrorMessage)) });
            await context.Response.WriteAsync(json);
        }
    }
}