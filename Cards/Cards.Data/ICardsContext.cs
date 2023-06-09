using Cards.Model;
using System.Collections.Generic;

namespace Cards.Data;

public interface ICardsContext
{
    IEnumerable<BasicCard> CardCollection { get; set; }
}
