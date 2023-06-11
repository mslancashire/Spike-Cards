using Cards.Model;
using FluentAssertions;

namespace Cards.API.Tests.Model;

public class CardTests
{
    [Fact]
    public void BlankCard_should_return_blank_default_settings()
    {
        // arrange

        // act
        var sut_BlankCard = new BlankCard();

        // assert
        sut_BlankCard.Name.Should().Be("Blank");
        sut_BlankCard.Cost.Should().Be(0);
        sut_BlankCard.Description.Should().Be("This card does nothing.");

        sut_BlankCard.Summary.Should().Be("C:0|H:0|A:0, Name:Blank, This card does nothing.");
    }

    [Fact]
    public void BasicCard_should_return_set_values()
    {
        // arrange

        // act
        var sut_BasicCard = new BasicCard
        {
            Name = "Test Card",
            Cost = 1,
            Health = 2,
            Attack = 3,
            Description = "This is a test card."
        };

        // assert
        sut_BasicCard.Name.Should().Be("Test Card");
        sut_BasicCard.Cost.Should().Be(1);
        sut_BasicCard.Health.Should().Be(2);
        sut_BasicCard.Attack.Should().Be(3);
        sut_BasicCard.Description.Should().Be("This is a test card.");

        sut_BasicCard.Summary.Should().Be("C:1|H:2|A:3, Name:Test Card, This is a test card.");
    }
}
