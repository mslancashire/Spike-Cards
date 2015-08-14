using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards.Readers
{
    public abstract class BaseLayoutReader : ICardsDisplay
    {
        public BaseLayoutReader(List<Card> cardsToRead)
            : this(cardsToRead, new LayoutSettings())
        { }

        public BaseLayoutReader(List<Card> cardsToRead, LayoutSettings layoutSettings)
        {
            this.cardsToRead = cardsToRead;
            this.layoutSettings = layoutSettings;
        }

        private List<Card> cardsToRead;
        private LayoutSettings layoutSettings;

        public abstract String DisplayCards();

        internal List<Card> CardsToRead
        {
            get { return this.cardsToRead; }
        }

        internal LayoutSettings LayoutSettings
        {
            get { return this.layoutSettings; }
        }

        public virtual String StartLine()
        {
            return new String(this.LayoutSettings.StartOfLine, this.LayoutSettings.NumberOfCharactersPerLine);
        }

        public virtual String SpacerLine()
        {
            return new String(this.LayoutSettings.CardWhitespace, this.LayoutSettings.NumberOfCharactersPerLine);
        }

        public virtual String EndLine()
        {
            return new String(this.LayoutSettings.EndOfLine, this.LayoutSettings.NumberOfCharactersPerLine);
        }
    }
}
