using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Cards;
using Domain.Cards.Readers;
using Test.CardLayouts;

namespace Test
{
    public sealed class MockFactory
    {
        private static MockFactory mockFactory = new MockFactory();

        private List<LayoutTest> layoutTests;
        private List<Card> listOfTestCards;

        static MockFactory()
        { }

        private MockFactory()
            : base()
        {
            // setup test cards
            listOfTestCards = new List<Card>();
            listOfTestCards.Add(new BasicCard("Test 1", 1, "This is the first test card."));
            listOfTestCards.Add(new BasicCard("Test 2", 2, "This is the secound test card."));
            listOfTestCards.Add(new BasicCard("Test 3", 3, "This is the third test card."));
            listOfTestCards.Add(new BasicCard("Test 4", 4, "This is the fourth test card."));
            listOfTestCards.Add(new BasicCard("Test 5", 5, "This is the fith test card."));
            listOfTestCards.Add(new BasicCard("Test 6", 6, "This is the sixth test card."));
            listOfTestCards.Add(new BasicCard("Test 7", 7, "This is the seventh test card."));
            listOfTestCards.Add(new BasicCard("Test 8", 8, "This is the eighth test card."));
            listOfTestCards.Add(new BasicCard("Test 9", 9, "This is the ninth test card."));
            listOfTestCards.Add(new BasicCard("Test 10", 10, "This is the tenth test card."));
            listOfTestCards.Add(new BasicCard("Test 11", 11, "This is the eventh test card."));
            listOfTestCards.Add(new BasicCard("Test 12", 12, "This is the twelfth test card."));

            // setup layouts
            var layoutSettingsDefault = LayoutSettings.GetDefaultLayout();
            var layoutSettingsBoxed = LayoutSettings.GetBoxedLayout();
            var layoutSettingsDoubleBoxed = LayoutSettings.GetDoubleBoxedLayout();

            // setup layout tests
            layoutTests = new List<LayoutTest>();
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-FullLine.txt", NumberOfCardsForTest = 5, LayoutSettings = layoutSettingsDefault });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-Missing.txt", NumberOfCardsForTest = 1, LayoutSettings = layoutSettingsDefault });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-MultipleLines.txt", NumberOfCardsForTest = 9, LayoutSettings = layoutSettingsDefault });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-FullLine.txt", NumberOfCardsForTest = 5, LayoutSettings = layoutSettingsBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-Missing.txt", NumberOfCardsForTest = 4, LayoutSettings = layoutSettingsBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-MultipleLines.txt", NumberOfCardsForTest = 9, LayoutSettings = layoutSettingsBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-FullLine.txt", NumberOfCardsForTest = 5, LayoutSettings = layoutSettingsDoubleBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-Missing.txt", NumberOfCardsForTest = 3, LayoutSettings = layoutSettingsDoubleBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-MultipleLines.txt", NumberOfCardsForTest = 7, LayoutSettings = layoutSettingsDoubleBoxed });
        }

        public static List<Card> GetInstanceOfTestCards
        {
            get { return mockFactory.listOfTestCards; }
        }

        public static List<LayoutTest> GetInstanceOfTestLayouts
        {
            get { return mockFactory.layoutTests; }
        }
    }
}
