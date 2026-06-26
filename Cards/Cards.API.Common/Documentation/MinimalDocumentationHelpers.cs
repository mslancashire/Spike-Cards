using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Cards.API.Common.Documentation;

public static class MinimalDocumentationHelpers
{
    public static RouteHandlerBuilder AllowAnonymous(this RouteHandlerBuilder endpoint)
    {
        endpoint.WithMetadata(new AllowAnonymousAttribute());

        return endpoint;
    }

    public static RouteHandlerBuilder AddStandardData<T>(this RouteHandlerBuilder endpoint, string summary, string description, params string[] tags)
    {
        endpoint.WithTags(tags);
        endpoint.WithSummary(summary);
        endpoint.WithDescription(description);

        endpoint.Produces<T>(200);
        endpoint.ProducesProblem(400);
        endpoint.ProducesProblem(500);
        
        return endpoint;
    }
}
