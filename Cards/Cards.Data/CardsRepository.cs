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

        public IEnumerable<Card> FindCardsByName(string nameToFind)
        {
            return _cardsContext.CardCollection.Where(c => c.Name == nameToFind);
        }

        public IEnumerable<Card> FindCardsByCost(int costToFind)
        {
            return _cardsContext.CardCollection.Where(c => c.Cost == costToFind);
        }

        public IEnumerable<Card> FindCardsByHealth(int healthToFind)
        {
            return _cardsContext.CardCollection.Where(c => c.Health == healthToFind);
        }

        public IEnumerable<Card> FindCardsByAttack(int attackToFind)
        {
            return _cardsContext.CardCollection.Where(c => c.Attack == attackToFind);
        }

        public IEnumerable<Card> FindCardsByDescription(string descriptionToFind)
        {
            return _cardsContext.CardCollection.Where(c => String.Compare(c.Description, descriptionToFind) > 0);
        }
    }
}
