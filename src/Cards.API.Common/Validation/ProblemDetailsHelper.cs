using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cards.API.Common.Validation;

public static class ProblemDetailsHelper
{
    public static ProblemDetails ToProblemDetails(this ValidationResult validationResult, HttpContext context)
    {
        return CreateProblemDetails(validationResult.ToDictionary(), context);
    }

    public static ProblemDetails ToProblemDetails(this ModelStateDictionary modelState, HttpContext context)
    {
        var errors = modelState.Where(e => e.Value is not null && e.Value.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        return CreateProblemDetails(errors, context);
    }

    private static HttpValidationProblemDetails CreateProblemDetails(IDictionary<string, string[]> errors, HttpContext context)
    {
        var problemOutput = new HttpValidationProblemDetails(errors)
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation failed",
            Detail = "One or more validation errors occurred.",
            Instance = context.Request.Path,
        };

        problemOutput.Extensions.TryAdd("traceId", context.TraceIdentifier);

        return problemOutput;
    }
}
