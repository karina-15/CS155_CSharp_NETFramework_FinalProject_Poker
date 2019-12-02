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
            Console.SetWindowSize(65, 40);
            // removes scroll bars
            Console.BufferWidth = 65;
            Console.BufferHeight = 40;
            Console.Title = "Poker Game";
            Deal deal = new Deal();
            bool quit = false;

            while(!quit)
            {
                deal.DealCards();
                char choice = ' ';
                while(!choice.Equals('y') && !choice.Equals('n'))
                {
                    Console.WriteLine("Play again? (y/n)");
                    choice = Convert.ToChar(Console.ReadLine().ToLower());

                    if(choice.Equals('y'))
                    {
                        quit = false;
                    }
                    else if(choice.Equals('n'))
                    {
                        quit = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Try again");
                    }
                }
            } // END OF while
        } // END OF Main
    }
}
