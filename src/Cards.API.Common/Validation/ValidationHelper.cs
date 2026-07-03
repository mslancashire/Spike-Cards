using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Cards.API.Common.Validation;

public static class ValidationHelper
{
    public static RouteHandlerBuilder WithValidation(this RouteHandlerBuilder builder)
    {
        return builder.AddEndpointFilter<AutoValidationEndPointFilter>();
    }

    public static RouteGroupBuilder WithValidation(this RouteGroupBuilder builder)
    {
        return builder.AddEndpointFilter<AutoValidationEndPointFilter>();
    }
}
