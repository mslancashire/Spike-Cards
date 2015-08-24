using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Cards;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class CheckCardCollection
    {
        [TestMethod, TestCategory("Card Collection")]
        public void TestBaiscCardCollection()
        {
            var baiscCardCollection = CardCollection.GenerateBasicCollection();

            Assert.IsNotNull(baiscCardCollection, "Ensure basic card collection is created.");
            Assert.IsNotNull(baiscCardCollection.Cards, "Ensure cards in basic card collection is created.");
            Assert.IsTrue(baiscCardCollection.Cards.Count > 0, "Ensure there are cards in basic card collection.");
        }

        [TestMethod, TestCategory("Card Searching")]
        public void TestCardFilterByCost()
        {
            var testCards = MockFactory.GetInstanceOfTestCards;
            var filteredCards = new List<Card>(CardsUtility.FilterCardsByCost(testCards, 4));
            Assert.IsTrue(filteredCards.Count == 1, String.Format("When filtering by a cost of {0} we found {1}, when should have found {2}.", 4, filteredCards.Count, 1));

            filteredCards = new List<Card>(CardsUtility.FilterCardsByCost(testCards, 99));
            Assert.IsTrue(filteredCards.Count == 0, String.Format("When filtering by a cost of {0} we found {1}, when should have found {2}.", 99, filteredCards.Count, 0));

            filteredCards = new List<Card>(CardsUtility.FilterCardsByCost(testCards, 12));
            Assert.IsTrue(filteredCards.Count == 2, String.Format("When filtering by a cost of {0} we found {1}, when should have found {2}.", 12, filteredCards.Count, 2));
        }

        [TestMethod, TestCategory("Card Searching")]
        public void TestCardFilterByHealth()
        {
            var testCards = MockFactory.GetInstanceOfTestCards;
            var filteredCards = new List<Card>(CardsUtility.FilterCardsByHealth(testCards, 4));
            Assert.IsTrue(filteredCards.Count == 2, String.Format("When filtering by a health of {0} we found {1}, when should have found {2}.", 4, filteredCards.Count, 2));

            filteredCards = new List<Card>(CardsUtility.FilterCardsByHealth(testCards, 99));
            Assert.IsTrue(filteredCards.Count == 0, String.Format("When filtering by a health of {0} we found {1}, when should have found {2}.", 99, filteredCards.Count, 0));

            filteredCards = new List<Card>(CardsUtility.FilterCardsByHealth(testCards, 2));
            Assert.IsTrue(filteredCards.Count == 2, String.Format("When filtering by a health of {0} we found {1}, when should have found {2}.", 2, filteredCards.Count, 2));
        }

        [TestMethod, TestCategory("Card Searching")]
        public void TestCardFilterByAttach()
        {
            var testCards = MockFactory.GetInstanceOfTestCards;
            var filteredCards = new List<Card>(CardsUtility.FilterCardsByAttack(testCards, 1));
            Assert.IsTrue(filteredCards.Count == 2, String.Format("When filtering by a attack of {0} we found {1}, when should have found {2}.", 1, filteredCards.Count, 2));

            filteredCards = new List<Card>(CardsUtility.FilterCardsByAttack(testCards, 99));
            Assert.IsTrue(filteredCards.Count == 0, String.Format("When filtering by a attack of {0} we found {1}, when should have found {2}.", 99, filteredCards.Count, 0));

            filteredCards = new List<Card>(CardsUtility.FilterCardsByAttack(testCards, 5));
            Assert.IsTrue(filteredCards.Count == 1, String.Format("When filtering by a attack of {0} we found {1}, when should have found {2}.", 5, filteredCards.Count, 1));
        }
    }
}
