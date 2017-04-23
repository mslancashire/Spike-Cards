using System;
using System.Collections.Generic;
using System.Text;
using Cards.Model;
using System.Linq;

namespace Cards.Data
{
    public class CardsRepository : ICardsRepository
    {
        private ICardsContext _cardsContext;

        public CardsRepository(ICardsContext cardsContext)
        {
            _cardsContext = cardsContext;
        }

        public IEnumerable<Card> GetCardCollection()
        {
            return _cardsContext.CardCollection;
        }
    }
}
