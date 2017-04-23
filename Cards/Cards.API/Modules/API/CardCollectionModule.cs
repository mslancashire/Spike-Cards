using Cards.Data;
using Cards.Model;
using Nancy;
using Nancy.Responses;
using System.Collections.Generic;

namespace Cards.API.Modules.API
{
    public class CardCollectionModule : NancyModule
    {
        public CardCollectionModule(ICardsRepository cardRepository)
            : base("/api/cards")
        {

            Get("", p =>
            {
                return cardRepository.GetCardCollection();
            });
        }
    }
}
