using Cards.Model;
using System;

namespace Cards.Data
{
    public class CardEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset DateModified { get; set; }

        public Card Card { get; set; }
    }
}
