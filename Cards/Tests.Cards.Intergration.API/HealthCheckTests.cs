using System.Net;
using Tests.Cards.Integration.API.Setup;

namespace Tests.Cards.Integration.API;

[Trait("Category", "Integration")]
public class HealthCheckTests : BaseIntegrationTestFixture
{
    public HealthCheckTests(CustomWebApplicationFactory application) : base(application)
    {
    }

    [Fact]
    public async Task HealthCheck()
    {
        // arrange
        var cancellationToken = CancellationToken.None;

        // act
        var response = await _client.GetAsync("/_health", cancellationToken);

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
