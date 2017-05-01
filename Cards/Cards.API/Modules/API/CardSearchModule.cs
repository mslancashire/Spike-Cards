using Cards.Data;
using Nancy;

namespace Cards.API.Modules.API
{
    public class CardSearchModule : NancyModule        
    {
        public CardSearchModule(ICardsRepository cardRepository)
            : base("/api/cards/search/")
        {
            Get("/by-name/{name}", p =>
            {
                return cardRepository.FindCardsByName(p.name);
            });

            Get("/by-cost/{cost}", p =>
            {
                return cardRepository.FindCardsByCost(p.cost);
            });

            Get("/by-health/{health}", p =>
            {
                return cardRepository.FindCardsByHealth(p.health);
            });

            Get("/by-attack/{attack}", p =>
            {
                //var attack = Request.Query.attack;
                return cardRepository.FindCardsByAttack(p.attack);
            });

            Get("/by-description/{description}", p =>
            {
                return cardRepository.FindCardsByDescription(p.description);
            });
        }
    }
}
