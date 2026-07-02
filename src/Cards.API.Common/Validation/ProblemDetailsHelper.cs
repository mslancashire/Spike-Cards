using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Common.Validation;

public static class ProblemDetailsHelper
{
    public static ProblemDetails? ToProblemDetails(this ValidationResult validationResult, string instanceName)
    {
        if (validationResult.IsValid)
        {
            return null;
        }

        return new HttpValidationProblemDetails(validationResult.ToDictionary())
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation failed",
            Detail = "One or more validation errors occurred.",
            Instance = instanceName
        };
    }
}
