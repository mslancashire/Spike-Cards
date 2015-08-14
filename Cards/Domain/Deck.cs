using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Deck : CardCollection
    {
        public Deck() :
            base()
        { }

        public static Deck GenerateRandomDeck(CardCollection cardCollection, Int32 deckSize)
        {
            var deck = new Deck();
            var deckSource = cardCollection;
            //var deckSource = new CardCollection(cardCollection.Cards); // create new list so we don't mess with the actual card collection

            if (deckSource.Cards.Count < deckSize)
            {
                throw new InvalidOperationException(String.Format("Can not create a deck of size {0}, as the card collection provided does not contain enough cards to select from ({1}).", deckSize, cardCollection.Cards.Count));
            }

            while (deck.Cards.Count < deckSize && cardCollection.Cards.Count > 0)
            {
                var rnd = new Random();
                var index = rnd.Next(deckSource.Cards.Count - 1);
                deck.Cards.Add(deckSource.Cards[index]);
                deckSource.Cards.RemoveAt(index);
            }
              
            return deck;
        }
    }
}
