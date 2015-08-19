using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Test
{
    [TestClass]
    public class CheckDeck
    {
        [TestMethod, TestCategory("Card")]
        public void TestBasicDesk()
        {
            var deckSize = 5;
            var cardCollection = CardCollection.GenerateBasicCollection();
            var countOfCardsInCollection = cardCollection.Cards.Count;
            var basicDeck = Deck.GenerateRandomDeck(cardCollection, deckSize);

            Assert.IsNotNull(basicDeck, "Ensure basic deck is created.");
            Assert.IsNotNull(basicDeck.Cards, "Ensure basic deck contains cards.");
            Assert.IsTrue(basicDeck.Cards.Count == deckSize, "Ensure basic deck contains the required number of cards (deck size).");
            Assert.IsTrue(cardCollection.Cards.Count + deckSize == countOfCardsInCollection, String.Format("The card collection has the wrong number of cards remaining, was {0}, now is {1} with a deck size of {2}.", countOfCardsInCollection, cardCollection.Cards.Count, deckSize));
        }
    }
}
