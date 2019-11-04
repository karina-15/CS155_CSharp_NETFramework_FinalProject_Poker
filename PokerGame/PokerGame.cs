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
            Console.Write(deck.GetDeck());

            Console.ReadKey();  // prevents window from closing
        }
    }
}
