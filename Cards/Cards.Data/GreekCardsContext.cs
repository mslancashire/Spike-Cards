namespace Cards.Data
{
    public class GreekCardsContext
    {
        private IList<Card> _cardCollection;
        
        public GreekCardsContext()
        {
            _cardCollection = new List<Card>();

            var cardNames = GreekCardNames.Instance;
            var rdNum = new Random();

            for (Int32 i = 0; i < cardNames.Count; i++)
            {
                var card = new BasicCard(cardNames[i].Name, i, cardNames[i].Description);

                card.Cost = rdNum.Next(0,10);
                card.Attack = rdNum.Next(0,20);
                card.Health = rdNum.Next(0,20);

                _cardCollection.Add(card);
            }
            return cardCollection;
        }
    }
}