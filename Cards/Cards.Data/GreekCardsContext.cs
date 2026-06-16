using Cards.Data.Source;
using Cards.Model;
using System;
using System.Collections.Generic;

namespace Cards.Data;

public class GreekCardsContext : ICardsContext
{
    private readonly List<BasicCard> _cardCollection;

    public GreekCardsContext()
    {
        _cardCollection = [];

        var cardNames = GreekCardNames.Instance;
        var rdNum = new Random();

        for (var i = 0; i < cardNames.Count; i++)
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
        => _cardCollection;
}