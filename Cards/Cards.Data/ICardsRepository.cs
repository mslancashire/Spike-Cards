using Cards.Model;
using System.Collections.Generic;

namespace Cards.Data;

public interface ICardsRepository
{
    IEnumerable<BasicCard> GetCardCollection();

    IEnumerable<BasicCard> FindCardsByName(string nameToFind);

    IEnumerable<BasicCard> FindCardsByCost(int costToFind);

    IEnumerable<BasicCard> FindCardsByHealth(int healthToFind);

    IEnumerable<BasicCard> FindCardsByAttack(int attackToFind);

    IEnumerable<BasicCard> FindCardsByDescription(string descriptionToFind);
}
