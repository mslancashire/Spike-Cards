using Cards.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cards.API.Health
{
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
                _cardsRepository.GetCardCollection();

                return HealthCheckResult.Healthy();
            }
            catch (Exception exception)
            {
                return HealthCheckResult.Unhealthy(exception: exception);
            }
        }
    }
}
