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
            FilterCheck[] checks = new FilterCheck[]
                                        {
                                            new FilterCheck { filterBy = 1, countShouldBe = 1, filterType = "cost" },
                                            new FilterCheck { filterBy = 99, countShouldBe = 0, filterType = "cost"},
                                            new FilterCheck { filterBy = 12, countShouldBe = 2, filterType = "cost"}
                                        };

            foreach (FilterCheck filterTest in checks)
            {
                var filteredCards = new List<Card>(CardsUtility.FilterCardsByCost(testCards, filterTest.filterBy));
                Assert.AreEqual(filterTest.countShouldBe, filteredCards.Count, filterTest.AssertMessage(filteredCards.Count));
            }
        }

        [TestMethod, TestCategory("Card Searching")]
        public void TestCardFilterByHealth()
        {
            var testCards = MockFactory.GetInstanceOfTestCards;
            FilterCheck[] checks = new FilterCheck[]
                                       {
                                            new FilterCheck { filterBy = 4, countShouldBe = 2, filterType = "health" },
                                            new FilterCheck { filterBy = 99, countShouldBe = 0, filterType = "health"},
                                            new FilterCheck { filterBy = 2, countShouldBe = 2, filterType = "health"}
                                       };

            foreach (FilterCheck filterTest in checks)
            {
                var filteredCards = new List<Card>(CardsUtility.FilterCardsByHealth(testCards, filterTest.filterBy));
                Assert.AreEqual(filterTest.countShouldBe, filteredCards.Count, filterTest.AssertMessage(filteredCards.Count));
            }
        }

        [TestMethod, TestCategory("Card Searching")]
        public void TestCardFilterByAttack()
        {
            var testCards = MockFactory.GetInstanceOfTestCards;
            FilterCheck[] checks = new FilterCheck[]
                                       {
                                            new FilterCheck { filterBy = 1, countShouldBe = 2, filterType = "attack" },
                                            new FilterCheck { filterBy = 99, countShouldBe = 0, filterType = "attack"},
                                            new FilterCheck { filterBy = 5, countShouldBe = 1, filterType = "attack"}
                                       };

            foreach (FilterCheck filterTest in checks)
            {
                var filteredCards = new List<Card>(CardsUtility.FilterCardsByAttack(testCards, filterTest.filterBy));
                Assert.AreEqual(filterTest.countShouldBe, filteredCards.Count, filterTest.AssertMessage(filteredCards.Count));
            }
        }

        struct FilterCheck
        {
            internal Int32 filterBy;
            internal Int32 countShouldBe;
            internal String filterType;

            internal String AssertMessage(Int32 actualCount)
            {
                return String.Format("When filtering by {0} with a value of {1}, we found {2} cards but should have found {3}.", filterType, filterBy, actualCount, countShouldBe);
            }
        }
    }
}
