using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Test
{
    [TestClass]
    public class CheckCardCollection
    {
        [TestMethod]
        public void TestBaiscCardCollection()
        {
            var baiscCardCollection = CardCollection.GenerateBasicCollection();

            Assert.IsNotNull(baiscCardCollection, "Ensure basic card collection is created.");
            Assert.IsNotNull(baiscCardCollection.Cards, "Ensure cards in basic card collection is created.");
            Assert.IsTrue(baiscCardCollection.Cards.Count > 0, "Ensure there are cards in basic card collection.");
        }
    }
}
