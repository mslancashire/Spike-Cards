using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards.Readers
{
    public class SummaryCardReader : BaseCardReader, ICardReader
    {
        public SummaryCardReader(List<Card> cardsToRead)
            : base(cardsToRead)
        { }

        public override String DisplayCards()
        {
            var cardOutputBuilder = new StringBuilder();            

            for (var i = 0; i < this.CardsToRead.Count; i++)
            {
                cardOutputBuilder.AppendLine(String.Format("Hand Position {0}) {1}", i + 1, this.CardsToRead[i].Summary));
            }            

            return cardOutputBuilder.ToString();
        }
    }
}
