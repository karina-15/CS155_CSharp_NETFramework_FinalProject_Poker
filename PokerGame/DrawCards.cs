using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class DrawCards
    {
        public static void DrawCardOutline(int xcoord, int ycoord)
        {
            Console.ForegroundColor = ConsoleColor.White;

            int x = xcoord * 12;
            int y = ycoord;

            Console.SetCursorPosition(x, y);
            Console.WriteLine(" __________");

            for(int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);

                if(i != 9)
                {
                    Console.WriteLine("|          |");
                }
                else
                {
                    Console.WriteLine("|__________|");
                }
            }
        }

        public static void DrawCardSuitRank(Card card, int xcoord, int ycoord)
        {
            char cardSuit = ' ';
            int x = xcoord * 12;
            int y = ycoord;
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

            Console.SetCursorPosition(x + 5, y + 5);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.Rank);
        }
    }
}
