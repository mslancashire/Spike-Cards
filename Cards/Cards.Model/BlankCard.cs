namespace Cards.Model
{
    public class BlankCard : Card
    {
        public BlankCard()
        {
            Name = "Blank";
            Cost = 0;
            Description = "This card does nothing.";
        }
    }
}
