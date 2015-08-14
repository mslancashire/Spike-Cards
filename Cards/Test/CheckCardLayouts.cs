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
        private List<LayoutTest> layoutTests;
        private List<Card> listOfTestCards;
        
        [TestInitialize]
        public void SetupTests()
        {
            // setup layouts
            var layoutSettingsDefault = LayoutSettings.GetDefaultLayout();
            var layoutSettingsBoxed = LayoutSettings.GetBoxedLayout();
            var layoutSettingsDoubleBoxed = LayoutSettings.GetDoubleBoxedLayout();

            // setup test cards
            this.listOfTestCards = new List<Card>();
            this.listOfTestCards.Add(new BasicCard("Test 1", 1, "This is the first test card."));
            this.listOfTestCards.Add(new BasicCard("Test 2", 2, "This is the secound test card."));
            this.listOfTestCards.Add(new BasicCard("Test 3", 3, "This is the third test card."));
            this.listOfTestCards.Add(new BasicCard("Test 4", 4, "This is the fourth test card."));
            this.listOfTestCards.Add(new BasicCard("Test 5", 5, "This is the fith test card."));
            this.listOfTestCards.Add(new BasicCard("Test 6", 6, "This is the sixth test card."));
            this.listOfTestCards.Add(new BasicCard("Test 7", 7, "This is the seventh test card."));
            this.listOfTestCards.Add(new BasicCard("Test 8", 8, "This is the eighth test card."));
            this.listOfTestCards.Add(new BasicCard("Test 9", 9, "This is the ninth test card."));
            this.listOfTestCards.Add(new BasicCard("Test 10", 10, "This is the tenth test card."));
            this.listOfTestCards.Add(new BasicCard("Test 11", 11, "This is the eventh test card."));
            this.listOfTestCards.Add(new BasicCard("Test 12", 12, "This is the twelfth test card."));

            // setup layout tests
            this.layoutTests = new List<LayoutTest>();
            this.layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-FullLine.txt", NumberOfCardsForTest = 5, LayoutSettings = layoutSettingsDefault });
            this.layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-Missing.txt", NumberOfCardsForTest = 1, LayoutSettings = layoutSettingsDefault });
            this.layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-MultipleLines.txt", NumberOfCardsForTest = 9, LayoutSettings = layoutSettingsDefault });
            this.layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-FullLine.txt", NumberOfCardsForTest = 5, LayoutSettings = layoutSettingsBoxed });
            this.layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-Missing.txt", NumberOfCardsForTest = 4, LayoutSettings = layoutSettingsBoxed });
            this.layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-MultipleLines.txt", NumberOfCardsForTest = 9, LayoutSettings = layoutSettingsBoxed });
            this.layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-FullLine.txt", NumberOfCardsForTest = 5, LayoutSettings = layoutSettingsDoubleBoxed });
            this.layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-Missing.txt", NumberOfCardsForTest = 3, LayoutSettings = layoutSettingsDoubleBoxed });
            this.layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-MultipleLines.txt", NumberOfCardsForTest = 7, LayoutSettings = layoutSettingsDoubleBoxed });
        }

        [TestMethod]
        public void TestCardLayouts()
        {
            foreach(LayoutTest layoutTest in this.layoutTests)
            {                
                List<Card> testCards = new List<Card>(this.listOfTestCards.GetRange(0, layoutTest.NumberOfCardsForTest));
                ICardsDisplay cardDisplay = new CardLayoutReader(testCards, layoutTest.LayoutSettings);

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
