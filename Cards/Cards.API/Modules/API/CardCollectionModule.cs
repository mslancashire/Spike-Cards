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
            Get("/", p =>
            {
                return cardRepository.GetCardCollection();
            });

            Get("/find-by-name/{name}", p =>
            {
                return cardRepository.FindCardsByName(p.name);
            });

            Get("/find-by-cost/{cost}", p =>
            {
                return cardRepository.FindCardsByCost(p.cost);
            });

            Get("/find", p =>
            {
                var health = Request.Query.health;
                return cardRepository.FindCardsByHealth(health);
            });

            Get("/find", p =>
            {
                var attack = Request.Query.attack;
                return cardRepository.FindCardsByAttack(attack);
            });

            Get("/find-by-description/{description}", p =>
            {
                return cardRepository.FindCardsByDescription(p.description);
            });
        }
    }
}
