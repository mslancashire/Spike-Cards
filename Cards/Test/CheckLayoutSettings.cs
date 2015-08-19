using Domain.Cards;
using Domain.Cards.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    [TestClass]
    public class CheckLayoutSettings
    {
        [TestMethod, TestCategory("Layout Settings")]
        public void TestDefaultLayoutSettings()
        {
            LayoutSettings layoutSettings = new LayoutSettings();
            Assert.AreEqual(5, layoutSettings.NumberOfCardsPerLine, "Number of cards per line should be 5.");
            Assert.AreEqual(80, layoutSettings.NumberOfCharactersPerLine, "Number of characters per line should be 80.");
            Assert.AreEqual(16, layoutSettings.NumberOfCharactersPerCard, "Number of characters per card should be 16.");
            Assert.AreEqual(14, layoutSettings.NumberOfCharactersInternalToCard, "Number of characters availible inside the card should be 14.");
        }

        [TestMethod, TestCategory("Layout Settings")]
        public void TestCustomLayouttSettings()
        {
            var charsPerLine = 500;
            var cardsPerLine = 10;

            LayoutSettings layoutSettings = new LayoutSettings(charsPerLine, cardsPerLine);

            Assert.AreEqual(cardsPerLine, layoutSettings.NumberOfCardsPerLine);
            Assert.AreEqual(charsPerLine, layoutSettings.NumberOfCharactersPerLine);
            Assert.AreEqual(charsPerLine / cardsPerLine, layoutSettings.NumberOfCharactersPerCard);
            Assert.AreEqual((charsPerLine / cardsPerLine) - 2, layoutSettings.NumberOfCharactersInternalToCard);
        }       
    }
}
