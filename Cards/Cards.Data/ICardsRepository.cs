using Cards.Model;
using System;
using System.Collections.Generic;

namespace Cards.Data
{
    public interface ICardsRepository
    {
        IEnumerable<Card> GetCardCollection();
    }
}
