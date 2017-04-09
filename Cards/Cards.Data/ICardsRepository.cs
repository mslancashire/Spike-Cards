using System;

namespace Cards.Data
{
    public interface ICardsRepository
    {
        IList<Card> CardCollection {get; set;}
    }
}
