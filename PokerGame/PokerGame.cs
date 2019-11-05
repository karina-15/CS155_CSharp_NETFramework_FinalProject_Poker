using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class PokerGame
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            foreach(Card card in deck.GetDeck())
            {
                Console.WriteLine(card);
            }

            Hand hand = new Hand();
/*
            foreach(Hand card1 in hand)
            {
                Console.WriteLine(card1);
            }
*/

            Console.ReadKey();  // prevents window from closing
        }
    }
}
