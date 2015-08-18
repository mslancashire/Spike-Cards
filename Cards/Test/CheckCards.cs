using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Cards;

namespace Test
{
    [TestClass]
    public class CheckCards
    {
        [TestMethod]
        public void TestBlankCard()
        {
            var blankCard = new BlankCard();
            Assert.IsInstanceOfType(blankCard, typeof(Card), "Check blank card is of correct type.");
            Assert.IsNotNull(blankCard.Name, "Check blank card name is populated.");
            Assert.IsNotNull(blankCard.Cost, "Check blank card cost is populated.");
            Assert.IsNotNull(blankCard.Health, "Check blank card health is populated.");
            Assert.IsNotNull(blankCard.Attack, "Check blank card attack is populated.");
            Assert.IsNotNull(blankCard.Description, "Check blank description is populated.");
            Assert.AreEqual("C:0|H:0|A:0, Name:Blank, This card does nothing.", blankCard.Summary, "Check blank card summary is correct.");
        }

        [TestMethod]
        public void TestBasicCard()
        {
            var name = "Basic";
            var cost = 1;
            var health = 5;
            var attack = 2;
            var description = "This is a test of a basic card description";
            var basicCard = new BasicCard(name, cost, health, attack, description);
            Assert.AreEqual(cost, basicCard.Cost, "Check basic card cost is populated.");
            Assert.AreEqual(description, basicCard.Description, "Check basic card description is populated.");
            Assert.AreEqual(name, basicCard.Name, "Check basic card name is populated.");
            Assert.AreEqual(String.Format("C:{0}|H:{1}|A:{2}, Name:{3}, {4}", cost, health, attack, name, description), basicCard.Summary, "Check basic card summary is correct.");
            Assert.AreEqual(attack, basicCard.Attack, "Check basic card attack is populated.");
            Assert.AreEqual(health, basicCard.Health, "Check basic card health is populated.");
        }
    }
}
