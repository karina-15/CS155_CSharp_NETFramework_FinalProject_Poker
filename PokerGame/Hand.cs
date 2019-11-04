using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Hand
    {
        private const int HAND_SIZE = 5;
        private Card[] hand;

        public int Size { get { return hand.Length; } }

        public Hand()
        {
            hand = new Card[HAND_SIZE];
        }

        public Hand(Card[] cards) : this()
        {
            for(int i = 0; i < hand.Length; i++)
            {
                hand[i] = cards[i];
            }
        }

        public Card this[int index]
        {
            get
            {
                if(index < 0 || index > hand.Length - 1)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return hand[index];
            }
            set
            {
                if(index < 0 || index > hand.Length - 1)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                hand[index] = value;
            }
        }
    }
}
