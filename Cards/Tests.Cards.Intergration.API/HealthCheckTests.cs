using System.Net;
using Tests.Cards.Integration.API.Setup;

namespace Tests.Cards.Integration.API;

[Trait("Category", "Integration")]
public class HealthCheckTests : BaseIntegrationTestFixture
{
    public HealthCheckTests(CustomWebApplicationFactory application) : base(application)
    {
    }

    [Theory]
    [InlineData("ready")]
    [InlineData("live")]
    public async Task HealthCheck(string type)
    {
        // arrange
        var cancellationToken = CancellationToken.None;

        // act
        var response = await _client.GetAsync($"/healthz/{type}", cancellationToken);

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
