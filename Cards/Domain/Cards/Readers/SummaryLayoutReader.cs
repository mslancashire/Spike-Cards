using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards.Readers
{
    public class SummaryLayoutReader : BaseLayoutReader, ICardsDisplay
    {
        public SummaryLayoutReader(List<Card> cardsToRead)
            : base(cardsToRead)
        { }

        public override String DisplayCards()
        {
            var cardOutputBuilder = new StringBuilder();
            cardOutputBuilder.AppendLine(this.StartLine());
            cardOutputBuilder.AppendLine(this.SpacerLine());

            for (var i = 0; i < this.CardsToRead.Count; i++)
            {
                cardOutputBuilder.AppendLine(String.Format("Hand Position {0}) {1}", i + 1, this.CardsToRead[i].Summary));
            }

            cardOutputBuilder.AppendLine(this.SpacerLine());
            cardOutputBuilder.AppendLine(this.EndLine());

            return cardOutputBuilder.ToString();
        }
    }
}
