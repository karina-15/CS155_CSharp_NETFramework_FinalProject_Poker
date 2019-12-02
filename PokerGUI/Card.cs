using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Card
    {
        // suit and rank enumerations
        public enum SUIT
        {
            HEARTS,
            SPADES,
            DIAMONDS,
            CLUBS
        }

        public enum RANK
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
            EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }

        // Properties
        public SUIT Suit { get; set; }
        public RANK Rank { get; set; }
    }
}
