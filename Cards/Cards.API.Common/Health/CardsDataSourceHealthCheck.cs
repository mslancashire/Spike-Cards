using Cards.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cards.API.Common.Health;

public class CardsDataSourceHealthCheck : IHealthCheck
{
    private readonly ICardsRepository _cardsRepository;

    public CardsDataSourceHealthCheck
    (
        ICardsRepository cardsRepository
    )
    {
        _cardsRepository = cardsRepository;
    }

    public async Task<HealthCheckResult> CheckHealthAsync
    (
        HealthCheckContext context,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var cards = await _cardsRepository.GetCardCollection();
            if (cards.Any())
            {
                return HealthCheckResult.Healthy();
            }
        }
        catch (Exception exception)
        {
            return HealthCheckResult.Unhealthy(exception: exception);
        }

        return HealthCheckResult.Degraded("Data not returned from DB.");
    }
}
