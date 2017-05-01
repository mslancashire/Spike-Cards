using Cards.API.Tests.TestHelpers;
using Cards.Model;
using Nancy.Testing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Cards.API.Tests.Modules.API
{
    public class CardCollectionModuleTests : TestBase
    {
        [Fact]
        public async Task GetCardCollection_should_should_a_list_of_cards()
        {
            // arrange

            // act
            var response = await Browser.Get("/api/cards", with =>
            {
                with.HttpRequest();
                with.Accept("application/json");
            });

            var info = response.Body.AsString();
            var cards = response.Body.DeserializeJson<IEnumerable<BasicCard>>();

            // assert
            Assert.True(response.StatusCode == Nancy.HttpStatusCode.OK, "Check response status code is OK.");
            Assert.NotEmpty(cards);
        }
    }
}
