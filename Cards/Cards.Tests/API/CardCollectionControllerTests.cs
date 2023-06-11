using Cards.API.Controllers;
using Cards.Data;
using Cards.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cards.Tests.API
{
    public class CardCollectionControllerTests
    {
        private readonly Mock<ILogger<CardCollectionController>> _mockLogger;
        private readonly Mock<ICardsRepository> _mockCardsRepository;

        public CardCollectionControllerTests()
        {
            _mockLogger = new Mock<ILogger<CardCollectionController>>();
            _mockCardsRepository = new Mock<ICardsRepository>();
        }

        private CardCollectionController CreateSUT()
        {
            return new CardCollectionController(_mockLogger.Object, _mockCardsRepository.Object);
        }

        private BasicCard CreateTestCard(string name)
        {
            return new BasicCard
            {
                Name = name
            };
        }

        [Fact]
        public void GetCards_should_return_a_collection_of_cards_with_ok()
        {
            // arrange
            var cards = new[]
            {
                CreateTestCard("Test 1"),
                CreateTestCard("Test 2")
            };

            _mockCardsRepository
                .Setup(mock => mock.GetCardCollection())
                .Returns(() => cards);
            
            var sut = CreateSUT();

            // act
            var result = sut.GetCards();

            // assert
            result.Should().NotBeNull();

            var okResult = (OkObjectResult) result;
            okResult.Value.Should().BeEquivalentTo(cards);
            okResult.StatusCode.Should().Be(200);
        }
    }
}
