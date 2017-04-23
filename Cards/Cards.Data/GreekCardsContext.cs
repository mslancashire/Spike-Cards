using Cards.Data.Source.GreekCardNames;
using Cards.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Data
{
    public class GreekCardsContext : ICardsContext
    {
        private IList<Card> _cardCollection;

        public GreekCardsContext()
        {
            _cardCollection = new List<Card>();

            var cardNames = GreekCardNames.Instance;
            var rdNum = new Random();

            for (Int32 i = 0; i < cardNames.Count; i++)
            {
                var card = new BasicCard(cardNames[i].Name, i, cardNames[i].Description)
                {
                    Cost = rdNum.Next(0, 10),
                    Attack = rdNum.Next(0, 20),
                    Health = rdNum.Next(0, 20)
                };
                _cardCollection.Add(card);
            }
        }

        public IEnumerable<Card> CardCollection
        {
            get
            {
                return _cardCollection;
            }
            set
            {
                _cardCollection = value.ToList();
            }
        }
    }
}