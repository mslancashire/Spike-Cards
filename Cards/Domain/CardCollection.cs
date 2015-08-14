using Domain.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// The collection of cards that a deck can be built out of.
    /// </summary>
    public class CardCollection
    {
        public CardCollection()
        {
            this.cards = new List<Card>();
        }

        public CardCollection(List<Card> cards)
        {
            this.cards = new List<Card>(cards);
        }

        /// <summary>
        /// A factory method thats creates a card collection and populates it with a basic card set.
        /// </summary>
        /// <returns></returns>
        public static CardCollection GenerateBasicCollection()
        {
            var cardNames = GreekCardNames.Instance;
            var cardCollection = new CardCollection();

            for (Int32 i = 0; i < cardNames.Count; i++)
            {
                cardCollection.cards.Add(new BasicCard(cardNames[i].Name, i, cardNames[i].Description));
            }
            return cardCollection;
        }
        
        private List<Card> cards;

        /// <summary>
        /// The cards contained in the current collection.
        /// </summary>
        public List<Card> Cards
        {
            get { return this.cards; }
        }
    }
}
