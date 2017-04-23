using Cards.Model;
using System;
using System.Collections.Generic;

namespace Cards.Data
{
    public interface ICardsRepository
    {
        IEnumerable<Card> GetCardCollection();

        IEnumerable<Card> FindCardsByName(string nameToFind);

        IEnumerable<Card> FindCardsByCost(int costToFind);

        IEnumerable<Card> FindCardsByHealth(int healthToFind);

        IEnumerable<Card> FindCardsByAttack(int attackToFind);

        IEnumerable<Card> FindCardsByDescription(string descriptionToFind);
    }
}
