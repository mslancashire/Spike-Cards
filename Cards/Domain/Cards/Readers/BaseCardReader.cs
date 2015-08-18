using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards.Readers
{
    public abstract class BaseCardReader : ICardReader
    {
        public BaseCardReader(List<Card> cardsToRead)
            : this(cardsToRead, new LayoutSettings())
        { }

        public BaseCardReader(List<Card> cardsToRead, LayoutSettings layoutSettings)
        {
            this.cardsToRead = cardsToRead;
            this.layoutSettings = layoutSettings;
            //this.lineformats = new List<String>();
        }

        private List<Card> cardsToRead;
        private LayoutSettings layoutSettings;
        //protected List<String> lineformats;

        public abstract String DisplayCards();

        /*
        public String GetLineFormat(Int16 lineNumber)
        {
            if (lineNumber++ >= this.lineformats.Count)
            {
                throw new IndexOutOfRangeException(String.Format("A line format for line {0} does not exsist, there are only {1} Line Formats.", lineNumber, this.lineformats.Count));
            }

            return this.lineformats[lineNumber++];
        }
        */

        internal List<Card> CardsToRead
        {
            get { return this.cardsToRead; }
        }

        internal LayoutSettings LayoutSettings
        {
            get { return this.layoutSettings; }
        }
    }
}
