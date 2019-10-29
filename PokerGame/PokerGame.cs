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
            Card c1 = new Card(Suit.Diamond, Rank.Three);
            Console.WriteLine(c1.ToString());
            Console.ReadKey();
        }
    }
}
