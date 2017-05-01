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

        public IEnumerable<BasicCard> GetCardCollection()
        {
            return _cardsContext.CardCollection;
        }

        public IEnumerable<BasicCard> FindCardsByName(string nameToFind)
        {
            return _cardsContext.CardCollection.Where(c => c.Name == nameToFind);
        }

        public IEnumerable<BasicCard> FindCardsByCost(int costToFind)
        {
            return _cardsContext.CardCollection.Where(c => c.Cost == costToFind);
        }

        public IEnumerable<BasicCard> FindCardsByHealth(int healthToFind)
        {
            return _cardsContext.CardCollection.Where(c => c.Health == healthToFind);
        }

        public IEnumerable<BasicCard> FindCardsByAttack(int attackToFind)
        {
            return _cardsContext.CardCollection.Where(c => c.Attack == attackToFind);
        }

        public IEnumerable<BasicCard> FindCardsByDescription(string descriptionToFind)
        {
            return _cardsContext.CardCollection.Where(c => c.Description.Contains(descriptionToFind));
        }
    }
}
