using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cards.API.Common.Exceptions;

/// <summary>
/// Basic Exception Handler Middleware that catches unhandled exceptions and returns a standardized error response.
/// </summary>
/// <param name="next"></param>
/// <param name="logger"></param>
public sealed class GlobalExceptionHandlerMiddleware(
    RequestDelegate next,
    ILogger<GlobalExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {

            logger.LogError(ex, "An unhandled exception occurred while processing the request.");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(
                new ProblemDetails
                {
                    Type = ex.GetType().Name,
                    Title = "An error occurred while processing your request.",
                    Detail = ex.Message,
                });
        }
    }
}