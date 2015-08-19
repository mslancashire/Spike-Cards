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
            listOfTestCards.Add(new BasicCard("Test 2 has a long name.", 2, "This is the secound test card and has a very long description."));
            listOfTestCards.Add(new BasicCard("Test 3", 3, "This is the third test card and has an even longer description to make sure the full card middle layout is tested."));
            listOfTestCards.Add(new BasicCard("Test 4", 4, ""));
            listOfTestCards.Add(new BasicCard("Test 5", 5, ""));
            listOfTestCards.Add(new BasicCard("Test 6", 6, ""));
            listOfTestCards.Add(new BasicCard("Test 7", 7, ""));
            listOfTestCards.Add(new BasicCard("Test 8", 8, ""));
            listOfTestCards.Add(new BasicCard("Test 9", 9, ""));
            listOfTestCards.Add(new BasicCard("Test 10", 10, ""));
            listOfTestCards.Add(new BasicCard("Test 11", 11, ""));
            listOfTestCards.Add(new BasicCard("Test 12", 12, ""));

            // setup layouts
            var layoutSettingsDefault = LayoutSettings.GetDefaultLayout();
            var layoutSettingsBoxed = LayoutSettings.GetBoxedLayout();
            var layoutSettingsDoubleBoxed = LayoutSettings.GetDoubleBoxedLayout();

            List<String> bob = new List<String>();
            bob.GetEnumerator();

            // setup layout tests
            layoutTests = new List<LayoutTest>();
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-FullLine.txt", CardReader = new CardReader(listOfTestCards.GetRange(0, 5), layoutSettingsDefault) });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-Missing.txt", CardReader = new CardReader(listOfTestCards.GetRange(0, 1), layoutSettingsDefault) });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-MultipleLines.txt", CardReader = new CardReader(listOfTestCards.GetRange(0,9), layoutSettingsDefault) });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-FullLine.txt", CardReader = new CardReader(listOfTestCards.GetRange(0,5), layoutSettingsBoxed) });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-Missing.txt", CardReader = new CardReader(listOfTestCards.GetRange(0,4), layoutSettingsBoxed) });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-MultipleLines.txt", CardReader = new CardReader(listOfTestCards.GetRange(0,9), layoutSettingsBoxed) });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-FullLine.txt", CardReader = new TemplateBasedCardReader(listOfTestCards.GetRange(0,5), layoutSettingsDoubleBoxed, "Detailed.txt") });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-Missing.txt", CardReader = new TemplateBasedCardReader(listOfTestCards.GetRange(0,3), layoutSettingsDoubleBoxed, "Detailed.txt")  });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-MultipleLines.txt", CardReader = new TemplateBasedCardReader(listOfTestCards.GetRange(0, 12), layoutSettingsDoubleBoxed, "Detailed.txt") });
            /*
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-FullLine.txt", CardReader = new CardReader(listOfTestCards.GetRange(0, 5), layoutSettingsDefault), NumberOfCardsForTest = 5, LayoutSettings = layoutSettingsDefault});
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-Missing.txt", NumberOfCardsForTest = 1, LayoutSettings = layoutSettingsDefault });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Default-MultipleLines.txt", NumberOfCardsForTest = 9, LayoutSettings = layoutSettingsDefault });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-FullLine.txt", NumberOfCardsForTest = 5, LayoutSettings = layoutSettingsBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-Missing.txt", NumberOfCardsForTest = 4, LayoutSettings = layoutSettingsBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-Boxed-MultipleLines.txt", NumberOfCardsForTest = 9, LayoutSettings = layoutSettingsBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-FullLine.txt", NumberOfCardsForTest = 5, LayoutSettings = layoutSettingsDoubleBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-Missing.txt", NumberOfCardsForTest = 3, LayoutSettings = layoutSettingsDoubleBoxed });
            layoutTests.Add(new LayoutTest { FileForComparison = "TestCardLayout-DoubleBoxed-MultipleLines.txt", NumberOfCardsForTest = 12, LayoutSettings = layoutSettingsDoubleBoxed });
            */
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
