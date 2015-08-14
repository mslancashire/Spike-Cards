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
            Assert.IsNotNull(blankCard.Description, "Check blank description is populated.");
            Assert.IsTrue(blankCard.Summary == "Cost:0, Name:Blank, This card does nothing.", "Check blank card summary is correct.");
        }

        [TestMethod]
        public void TestBasicCard()
        {
            var name = "Basic";
            var cost = 1;
            var description = "This is a test of a basic card description";
            var basicCard = new BasicCard(name, cost, description);
            Assert.AreEqual(basicCard.Cost, cost, "Check basic card cost is populated.");
            Assert.AreEqual(basicCard.Description, description, "Check basic card description is populated.");
            Assert.AreEqual(basicCard.Name, name, "Check basic card name is populated.");
            Assert.AreEqual(basicCard.Summary, String.Format("Cost:{0}, Name:{1}, {2}", cost, name, description), "Check basic card summary is correct.");
        }
    }
}
