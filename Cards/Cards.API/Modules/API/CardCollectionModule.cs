using Cards.Data;
using Nancy;

namespace Cards.API.Modules.API
{
    public class CardCollectionModule : NancyModule
    {
        public CardCollectionModule(ICardsRepository cardRepository)
            : base("/api/cards")
        {
            Get("/", p =>
            {
                return cardRepository.GetCardCollection();
            });            
        }
    }
}
