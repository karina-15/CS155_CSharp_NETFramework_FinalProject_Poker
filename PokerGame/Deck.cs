using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Deck : Card
    {
        private const int DECK_SIZE = 52;
        private Card[] deck;

        public Deck()
        {
            deck = new Card[DECK_SIZE];
        }

        // getter for Deck
        public Card[] getDeck { get { return deck; } }

        // setter for Deck
        // creates a full Deck of 52 Cards
        public void SetDeck()
        {
            int i = 0;
            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach(RANK r in Enum.GetValues(typeof(RANK)))
                {
                    deck[i] = new Card { Suit = s, Rank = r };
                    i++;
                }
            }
            ShuffleCards();
        } // END OF SetDeck method

        // Shuffle Deck
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;

            // shuffle 1000 times
            for(int shuffleCount = 0; shuffleCount < 1000; shuffleCount++)
            {
                for(int i = 0; i < DECK_SIZE; i++)
                {
                    // swap cards
                    int card2 = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[card2];
                    deck[card2] = temp;
                }
            }
        } // END OF ShuffleCards method
    } // END OF Deck class
}
