using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards.Readers
{
    public class CardReader : BaseCardReader, ICardReader
    {
        public CardReader(List<Card> cardsToRead)
            : base(cardsToRead)
        { }

        public CardReader(List<Card> cardsToRead, LayoutSettings layoutSettings)
            : base(cardsToRead, layoutSettings)
        { }

        public override String DisplayCards()
        {
            var cardOuputBuilder = new StringBuilder();
            var indexOfReadCard = 0;

            while (indexOfReadCard < this.CardsToRead.Count)
            {
                var cardDisplay = new CardReader(this.CardsToRead.GetRange(indexOfReadCard, this.CountOfNextCardBatch(indexOfReadCard)), this.LayoutSettings);
                cardOuputBuilder.Append(cardDisplay.ReadCards());
                indexOfReadCard += this.LayoutSettings.NumberOfCardsPerLine;
            }            

            return cardOuputBuilder.ToString();
        }

        public Int32 CountOfNextCardBatch(Int32 currentCardIndex)
        {
            Int32 nextCount = this.LayoutSettings.NumberOfCardsPerLine;

            if (currentCardIndex + this.LayoutSettings.NumberOfCardsPerLine >= this.CardsToRead.Count)
            {
                nextCount = this.CardsToRead.Count - currentCardIndex;
            }            

            return nextCount;
        }
                
        internal String ReadCards()
        {
            var cardOuputBuilder = new StringBuilder();            

            //cardOuputBuilder.AppendLine(this.StartLine());
            //cardOuputBuilder.AppendLine(this.SpacerLine());
            cardOuputBuilder.AppendLine(this.StartLineOfCards());
            cardOuputBuilder.AppendLine(this.LineForCardName());
            cardOuputBuilder.AppendLine(this.LineForCardSpacer());
            cardOuputBuilder.AppendLine(this.LineForCardSpacer());
            cardOuputBuilder.AppendLine(this.LineForCardSpacer());
            cardOuputBuilder.AppendLine(this.LineForCardSpacer());
            cardOuputBuilder.AppendLine(this.LineForCardSpacer());
            cardOuputBuilder.AppendLine(this.LineForCardCost());            
            cardOuputBuilder.AppendLine(this.EndLineOfCards());
            //cardOuputBuilder.AppendLine(this.SpacerLine());
            //cardOuputBuilder.AppendLine(this.EndLine());

            return cardOuputBuilder.ToString();
        }

        public String StartLineOfCards()
        {
            String startLineOfCards = "";

            for (var i = 0; i < this.CardsToRead.Count; i++)
            {
                startLineOfCards += String.Format("{0}{1}{2}",
                       this.LayoutSettings.CardBorderTopLeft,
                       new  String(this.LayoutSettings.CardBorderTop, this.LayoutSettings.NumberOfCharactersInternalToCard),
                       this.LayoutSettings.CardBorderTopRight);
            }

            return startLineOfCards;
        }

        public String EndLineOfCards()
        {
            String endLineOfCards = "";

            for (var i = 0; i < this.CardsToRead.Count; i++)
            {
                endLineOfCards += String.Format("{0}{1}{2}",
                        this.LayoutSettings.CardBorderBottomLeft,
                        new String(this.LayoutSettings.CardBorderBottom, this.LayoutSettings.NumberOfCharactersInternalToCard),
                        this.LayoutSettings.CardBorderBottomRight);
            }

            return endLineOfCards;
        }

        public String LineForCardName()
        {
            String lineForCardName = "";

            for (var i = 0; i < this.CardsToRead.Count; i++)
            {
                String cardInner;
                Card card = this.CardsToRead[i];
                if (card.Name.Length < this.LayoutSettings.NumberOfCharactersInternalToCard)
                {
                    cardInner = card.Name.PadRight(this.LayoutSettings.NumberOfCharactersInternalToCard);
                }
                else
                {
                    cardInner = card.Name.Substring(0, this.LayoutSettings.NumberOfCharactersInternalToCard);
                }

                lineForCardName += String.Format("{0}{1}{2}", this.LayoutSettings.CardBorderLeft, cardInner, this.LayoutSettings.CardBorderRight);
            }

            return lineForCardName;
        }

        public String LineForCardSpacer()
        {
            String lineForCardSpacer = "";

            for (var i = 0; i < this.CardsToRead.Count; i++)
            {
                lineForCardSpacer += String.Format("{0}{1}{2}", this.LayoutSettings.CardBorderLeft, new String(this.LayoutSettings.CardWhitespace, this.LayoutSettings.NumberOfCharactersInternalToCard), this.LayoutSettings.CardBorderRight);
            }

            return lineForCardSpacer;
        }

        public String LineForCardCost()
        {
            String lineForCardCost = "";

            for (var i = 0; i < this.CardsToRead.Count; i++)
            {
                String cardInner;
                Card card = this.CardsToRead[i];
                String cardData = card.Cost.ToString();
                if (cardData.Length < this.LayoutSettings.NumberOfCharactersInternalToCard)
                {
                    cardInner = cardData.PadLeft(this.LayoutSettings.NumberOfCharactersInternalToCard);
                }
                else
                {
                    cardInner = cardData.Substring(0, this.LayoutSettings.NumberOfCharactersInternalToCard);
                }

                lineForCardCost += String.Format("{0}{1}{2}", this.LayoutSettings.CardBorderLeft, cardInner, this.LayoutSettings.CardBorderRight);
            }

            return lineForCardCost;
        }
    }
}
