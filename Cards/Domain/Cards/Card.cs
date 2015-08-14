using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards
{
    /// <summary>
    /// Playing card.
    /// </summary>
    public abstract class Card
    {
        /// <summary>
        /// Base Card
        /// </summary>
        /// <param name="name">The name of the playing card.</param>
        /// <param name="cost">The cost of putting the card into play.</param>
        /// <param name="description">The description of the card.</param>
        protected Card(String name, Int32 cost, String description)
        {
            this.name = name;
            this.cost = cost;
            this.description = description;
        }
        
        
        private String name;
        private Int32 cost;
        private String description;
        
        /// <summary>
        /// Name of playing card.
        /// </summary>
        public String Name
        {
            get { return this.name; }
            internal set { this.name = value; }
        }

        /// <summary>
        /// Cost of putting the card into play.
        /// </summary>
        public Int32 Cost
        {
            get { return this.cost; }
            internal set { this.cost = value; }
        }

        /// <summary>
        /// Description of playing card.
        /// </summary>
        public String Description
        {
            get { return this.description; }
            internal set { this.description = value; }
        }

        /// <summary>
        /// Summary of the properties and capibilites of the playing card.
        /// </summary>
        public String Summary
        {
            get { return String.Format("Cost:{0}, Name:{1}, {2}", this.Cost, this.Name, this.Description); }
        }
    }
}
