using Cards.Model;
using System.Net;
using Tests.Cards.Integration.API.Helpers;
using Tests.Cards.Integration.API.Setup;

namespace Tests.Cards.Integration.API;

[Trait("Category", "Integration")]
public class SmokeTests : BaseIntegrationTestFixture
{
    public SmokeTests(CustomWebApplicationFactory application) : base(application)
    {
    }

    [Theory]
    [InlineData("api/cards/get-cards")]
    [InlineData("api/cards/search/by-name/Phoebe")]
    [InlineData("api/cards/search/by-name/phoebe")]
    [InlineData("api/cards/search/by-cost/1")]
    [InlineData("api/cards/search/by-health/1")]
    [InlineData("api/cards/search/by-attack/1")]
    [InlineData("api/cards/search/by-description/goddess")]
    [InlineData("api/cards/search/by-description/Goddess")]
    public async Task GET_endpoints_should_return_ok(string endpoint)
    {
        // arrange
        var cancellation = CancellationToken.None;

        // act
        var response = await _client.GetAsync(endpoint, cancellation);

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var cards = await response.GetAs<IEnumerable<BasicCard>>();
        cards.Should().NotBeNull();
        cards.Should().NotBeEmpty();
    }
}
