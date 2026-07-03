using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Cards.API.Common.Validation;

public class AutoValidationEndPointFilter : IEndpointFilter
{
    private readonly IServiceProvider _serviceProvider;

    public AutoValidationEndPointFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        for (int i = 0; i < context.Arguments.Count; i++)
        {
            var argument = context.Arguments[i];
            if (argument is null)
            {
                continue;
            }

            var argumentType = argument.GetType();
            var validationType = typeof(IValidator<>).MakeGenericType(argumentType);

            var validator = _serviceProvider.GetService(validationType) as IValidator;
            if (validator is null)
            {
                continue;
            }

            var validationContext = new ValidationContext<object>(argument);
            var validationResult = await validator.ValidateAsync(validationContext);
            if (validationResult.IsValid)
            {
                continue;
            }

            return Results.Problem(validationResult.ToProblemDetails(context.HttpContext));
        }

        return await next(context);
    }
}
