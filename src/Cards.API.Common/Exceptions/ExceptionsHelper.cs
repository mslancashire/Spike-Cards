using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cards.API.Common.Exceptions;

public static class ExceptionsHelper
{
    public static WebApplication SetupCustomExceptionHandling(this WebApplication application)
    {
        application.UseMiddleware<GlobalExceptionHandlerMiddleware>();

        return application;
    }

    public static IServiceCollection SetupExceptionHandler(this IServiceCollection services)
    {
        services
            .AddProblemDetails(options =>
            {
                options.CustomizeProblemDetails = context =>
                {
                    context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
                };
            })
            .AddExceptionHandler<GlobalExceptionHandler>();
        
        return services;
    }

    public static WebApplication SetupExceptionHandling(this WebApplication application)
    {
        application.UseExceptionHandler();

        return application;
    }
}
