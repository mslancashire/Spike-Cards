using Cards.Data.Source.GreekCardNames;
using Cards.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Data
{
    public class GreekCardsContext : ICardsContext
    {
        private IList<BasicCard> _cardCollection;

        public GreekCardsContext()
        {
            _cardCollection = new List<BasicCard>();

            var cardNames = GreekCardNames.Instance;
            var rdNum = new Random();

            for (Int32 i = 0; i < cardNames.Count; i++)
            {
                var card = new BasicCard
                {
                    Name = cardNames[i].Name,
                    Description = cardNames[i].Description,
                    Cost = rdNum.Next(0, 10),
                    Attack = rdNum.Next(0, 20),
                    Health = rdNum.Next(0, 20)
                };               

                _cardCollection.Add(card);
            }

            // added to make test always work, due to random generation of card attributes
            _cardCollection[0].Cost = 1;
            _cardCollection[1].Health = 2;
            _cardCollection[2].Attack = 3;
        }

        public IEnumerable<BasicCard> CardCollection
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