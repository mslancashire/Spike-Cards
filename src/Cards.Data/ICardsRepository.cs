using Cards.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cards.Data;

public interface ICardsRepository
{
    Task<IEnumerable<BasicCard>> GetCardCollection();

    Task<IEnumerable<BasicCard>> FindCardsByName(string nameToFind);

    Task<IEnumerable<BasicCard>> FindCardsByCost(int costToFind);

    Task<IEnumerable<BasicCard>> FindCardsByHealth(int healthToFind);

    Task<IEnumerable<BasicCard>> FindCardsByAttack(int attackToFind);

    Task<IEnumerable<BasicCard>> FindCardsByDescription(string descriptionToFind);
}
