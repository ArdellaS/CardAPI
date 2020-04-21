using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Models
{
    public class CardPlay
    {
        public class Deck
        {
            public string DeckId { get; set; }

            public Card[] Cards { get; set; }

        }
        public class Card
        {
            public Uri Image { get; set; }
            public string Value { get; set; }
            public string Suit { get; set; }
        }

    }
}