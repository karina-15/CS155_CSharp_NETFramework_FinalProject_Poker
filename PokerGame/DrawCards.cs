using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class DrawCards
    {
        public static void DrawCardSuitRank(Card card, int xcoord, int ycoord)
        {
            char cardSuit = ' ';
            Console.OutputEncoding = Encoding.UTF8;

            switch(card.Suit)
            {
                case Card.SUIT.HEARTS:
                    cardSuit = Convert.ToChar("\u2665");
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.DIAMONDS:
                    cardSuit = Convert.ToChar("\u2666");
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.CLUBS:
                    cardSuit = Convert.ToChar("\u2663");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Card.SUIT.SPADES:
                    cardSuit = Convert.ToChar("\u2660");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.Write(card.Rank);
            Console.Write("\t");
            Console.WriteLine(cardSuit);
        }
    }
}
