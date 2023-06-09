using Cards.API.Tests.TestHelpers;
using Cards.Model;
using Nancy.Testing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Cards.API.Tests.Modules.API
{
    public class CardSearchModuleTests : TestBase
    {
        [Theory, MemberData("SearchTests")]
        public async Task SearchCards_should_return_valid_filtered_list_of_cards(string searchName, string itemToFilter, Action<BasicCard> checkAction)
        {
            // arrange
            var apiActionUri = $"/api/cards/search/by-{searchName}/{itemToFilter}";

            // act
            var response = await Browser.Get(apiActionUri, with =>
            {
                with.HttpRequest();
                with.Accept("application/json");
            });

            var results = response.Body.DeserializeJson<IEnumerable<BasicCard>>();

            // assert
            Assert.True(response.StatusCode == Nancy.HttpStatusCode.OK, "Check response status code is OK.");
            Assert.NotEmpty(results);
            Assert.All<BasicCard>(results, checkAction);
        }

        public static IEnumerable<object[]> SearchTests
        {
            get
            {
                return new[]
                {
                    new object[] { "name", "Tartarus", new Action<BasicCard>((card) => { Assert.Equal(card.Name, "Tartarus"); }) },
                    new object[] { "cost", "1", new Action<BasicCard>((card) => { Assert.Equal(card.Cost, 1); }) },
                    new object[] { "health", "2", new Action<BasicCard>((card) => { Assert.Equal(card.Health, 2); }) },
                    new object[] { "attack", "3", new Action<BasicCard>((card) => { Assert.Equal(card.Attack, 3); }) },
                    new object[] { "description", "goddess", new Action<BasicCard>((card) => { Assert.Contains("goddess", card.Description); }) }
                };
            }
        }
    }
}
