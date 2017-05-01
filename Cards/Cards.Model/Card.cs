using System;

namespace Cards.Model
{
    /// <summary>
    /// Playing card.
    /// </summary>
    public abstract class Card
    {
        public Card()
        { }

        private String name;
        private Int32 cost;
        private Int32 health;
        private Int32 attack;
        private String description;

        /// <summary>
        /// Name of the playing card.
        /// </summary>
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Cost of putting the card into play.
        /// </summary>
        public Int32 Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }

        /// <summary>
        /// Health of the card.
        /// </summary>
        public Int32 Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        /// <summary>
        /// Attack value of the card.
        /// </summary>
        public Int32 Attack
        {
            get { return this.attack; }
            set { this.attack = value; }
        }

        /// <summary>
        /// Description of the playing card.
        /// </summary>
        public String Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Summary of the properties and capibilites of the playing card.
        /// </summary>
        public String Summary
        {
            get { return String.Format("C:{0}|H:{1}|A:{2}, Name:{3}, {4}", this.Cost, this.Health, this.Attack, this.Name, this.Description); }
        }
    }
}
