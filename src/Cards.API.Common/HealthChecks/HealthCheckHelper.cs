using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cards.API.Common.HealthChecks;

public static class HealthCheckHelper
{
    public static IServiceCollection AddHealthAndLiveChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<CardsDBConnectionHealthCheck>("CardsDBConnection", HealthStatus.Unhealthy, ["ready"])
            .AddCheck<CardsDataSourceHealthCheck>("CardsDataSource", HealthStatus.Unhealthy, ["live"]);

        return services;
    }

    public static IEndpointRouteBuilder MapHealthAndLiveChecks(this IEndpointRouteBuilder builder)
    {
        builder.MapHealthChecks("/healthz/ready", new HealthCheckOptions
        {
            Predicate = healthCheck => healthCheck.Tags.Contains("ready"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        builder.MapHealthChecks("/healthz/live", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        return builder;
    }
}
