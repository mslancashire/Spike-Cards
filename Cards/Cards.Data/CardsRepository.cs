using Cards.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Data;

public class CardsRepository : ICardsRepository
{
    private ICardsContext _cardsContext;

    public CardsRepository(ICardsContext cardsContext)
    {
        _cardsContext = cardsContext;
    }

    public async Task<IEnumerable<BasicCard>> GetCardCollection()
        => await Task.FromResult(_cardsContext.CardCollection);

    public async Task<IEnumerable<BasicCard>> FindCardsByName(string nameToFind)
        => await Task.FromResult(_cardsContext.CardCollection.Where(c => c.Name.Equals(nameToFind, StringComparison.OrdinalIgnoreCase)));

    public async Task<IEnumerable<BasicCard>> FindCardsByCost(int costToFind)
        => await Task.FromResult(_cardsContext.CardCollection.Where(c => c.Cost == costToFind));

    public async Task<IEnumerable<BasicCard>> FindCardsByHealth(int healthToFind)
        => await Task.FromResult(_cardsContext.CardCollection.Where(c => c.Health == healthToFind));

    public async Task<IEnumerable<BasicCard>> FindCardsByAttack(int attackToFind)
        => await Task.FromResult(_cardsContext.CardCollection.Where(c => c.Attack == attackToFind));

    public async Task<IEnumerable<BasicCard>> FindCardsByDescription(string descriptionToFind)
        => await Task.FromResult(_cardsContext.CardCollection.Where(c => c.Description.Contains(descriptionToFind, StringComparison.OrdinalIgnoreCase)));
}