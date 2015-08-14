using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards
{
    public class BlankCard : Card
    {
        public BlankCard() :
            base("Blank", 0, "This card does nothing.")
        { }   
    }
}
