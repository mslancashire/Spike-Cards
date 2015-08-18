using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cards.Readers
{
    /// <summary>
    /// Providers a view on a list of cards.
    /// </summary>
    public interface ICardReader
    {        
        /// <summary>
        /// Providers a output string for a view on the provider list of cards.
        /// </summary>      
        /// <returns></returns>
        String DisplayCards();
    }
}
