using Domain.Cards;
using Domain.Cards.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Test.CardLayouts;

namespace Test
{
    [TestClass]
    public class CheckCardLayouts
    {
        [TestMethod]
        public void TestTemplateCardReader()
        {
            List<Card> listOfCards = MockFactory.GetInstanceOfTestCards;
            String testTemplate = "Test Template";

            TemplateBasedCardReader templateCardReader = new TemplateBasedCardReader(listOfCards, "Test.txt");
            Assert.IsNotNull(templateCardReader.CardTemplate);
            Assert.AreEqual(testTemplate, templateCardReader.CardTemplate);
        }


        [TestMethod]
        public void TestCardLayouts()
        {
            List<Card> listOfTestCards = MockFactory.GetInstanceOfTestCards;
            List<LayoutTest> layoutTests = MockFactory.GetInstanceOfTestLayouts;

            foreach (LayoutTest layoutTest in layoutTests)
            {                
                List<Card> testCards = new List<Card>(listOfTestCards.GetRange(0, layoutTest.NumberOfCardsForTest));
                ICardReader cardDisplay = new CardReader(testCards, layoutTest.LayoutSettings);

                var filePath = Path.Combine(Environment.CurrentDirectory, "CardLayouts", layoutTest.FileForComparison);

                using (FileStream fileForComparison = File.OpenRead(filePath))
                    using (StreamReader fileSteamReader = new StreamReader(fileForComparison, Encoding.UTF32 ,true))
                        using (StringReader cardReader = new StringReader(cardDisplay.DisplayCards()))
                        {
                            var lineNumber = 1;
                            while (true)
                            {
                                String fileLine = fileSteamReader.ReadLine();
                                String cardsLine = cardReader.ReadLine();

                                // break the loop if any output is null
                                if (fileLine == null && cardsLine == null)
                                {
                                    // comparison ended at correct position so end comparison
                                    break;
                                }
                                else if (fileLine != null && cardsLine == null)
                                {
                                    // not enough card lines outputted for comparison
                                    throw new AssertFailedException(String.Format("Line {0} did not provide a card line to compare for the {1} check.", lineNumber, layoutTest.FileForComparison));
                                }
                                else if (fileLine == null && cardsLine != null)
                                {
                                    // not enough comparison lines outputted for comparison
                                    throw new AssertFailedException(String.Format("Line {0} did not provide a file line to compare for the {1} check.", lineNumber, layoutTest.FileForComparison));
                                }

                                Assert.AreEqual(fileLine, cardsLine, String.Format("Line {0} did not match for the {1} card layout check.", lineNumber, layoutTest.FileForComparison));
                                lineNumber++;
                            }                            
                        }

            }
        }
    }
}
