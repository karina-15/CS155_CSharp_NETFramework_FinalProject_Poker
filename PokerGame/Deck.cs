using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Deck
    {
        private const int DECK_SIZE = 52;

        private Card[] deck;

        public int Size { get { return deck.Length; } }

        public Deck()
        {
            deck = GetDeck();
        }

        public Card this[int index]
        {
            get
            {
                if(index < 0 || index > deck.Length - 1)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return deck[index];
            }
            set
            {
                if(index < 0 || index > deck.Length - 1)
                {
                    throw new IndexOutOfRangeException("Index is out range.");
                }
                deck[index] = value;
            }
        }

        private static Card[] GetDeck()
        {
            Card[] temp = new Card[DECK_SIZE];
            int index = 0;

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    temp[index++] = new Card(suit, rank);
                }
            }
            return temp;
        }
    }
}
