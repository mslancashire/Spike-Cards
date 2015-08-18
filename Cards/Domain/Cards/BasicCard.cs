using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards
{
    public class BasicCard : Card
    {
        public BasicCard(String name, Int32 cost, String description)
           : base (name, cost, description)
        { }

        public BasicCard(String name, Int32 cost, Int32 health, Int32 attack, String description)
           : base (name, cost, health, attack, description)
        { }
    }
}
