using Cards.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Data
{
    public interface ICardsContext
    {
        IEnumerable<Card> CardCollection { get; set; }
    }
}
