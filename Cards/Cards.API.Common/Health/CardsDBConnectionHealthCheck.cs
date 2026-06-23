using Cards.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cards.API.Common.Health;

// TODO: Change to use a DB connection health check.

public class CardsDBConnectionHealthCheck : IHealthCheck
{
    private readonly ICardsRepository _cardsRepository;

    public CardsDBConnectionHealthCheck(ICardsRepository cardsRepository)
    {
        _cardsRepository = cardsRepository;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (_cardsRepository is not null)
        {
            return Task.FromResult(HealthCheckResult.Healthy());
        }

        return Task.FromResult(HealthCheckResult.Unhealthy("DB connection not available."));
    }
}
