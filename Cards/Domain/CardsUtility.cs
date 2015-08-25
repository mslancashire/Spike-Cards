using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Cards;

namespace Domain
{
    public static class CardsUtility
    {
        public static IEnumerable<Card> FilterCardsByCost(List<Card> cards, Int32 cost)
        {
            return cards.Where(c => c.Cost == cost);

            //return from card in cards where card.Cost == cost select card;
        }

        public static IEnumerable<Card> FilterCardsByAttack(List<Card> cards, Int32 attack)
        {
            return cards.Where(c => c.Attack == attack);
        }

        public static IEnumerable<Card> FilterCardsByHealth(List<Card> cards, Int32 health)
        {
            return cards.Where(c => c.Health == health);
        }
    }
}
