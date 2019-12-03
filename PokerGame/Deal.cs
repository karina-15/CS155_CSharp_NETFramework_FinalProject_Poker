using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Deal : Deck
    {
        private Card[] playerHand;
        private Card[] cpuHand;
        private Card[] sortedPlayerHand;
        private Card[] sortedCpuHand;

        public Deal()
        {
            playerHand = new Card[5];
            sortedPlayerHand = new Card[5];
            cpuHand = new Card[5];
            sortedCpuHand = new Card[5];
        }

        public void DealCards()
        {
            SetDeck();
            GetHand();
            SortCards();
            DisplayCards();
            EvaluateHands();
        }

        public void GetHand()
        {
            // deal 5 cards to player
            for(int i = 0; i < 5; i++)
            {
                playerHand[i] = getDeck[i];
            }

            // deal 5 cards to CPU
            for(int i = 5; i < 10; i++)
            {
                cpuHand[i - 5] = getDeck[i];
            }
        }

        public void SortCards()
        {
            // create queries for player and CPU
            var queryPlayer = from hand in playerHand
                              orderby hand.Rank
                              select hand;
            var queryCpu = from hand in cpuHand
                           orderby hand.Rank
                           select hand;

            // place sorted cards in array for player
            var index = 0;
            foreach(var element in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = element;
                index++;
            }

            // place sorted cards in array for CPU
            index = 0;
            foreach(var element in queryCpu.ToList())
            {
                sortedCpuHand[index] = element;
                index++;
            }
        } // END OF SortCards method

        public void DisplayCards()
        {
            Console.Clear();
            int x = 0;
            int y = 1;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Player's Hand");
            for(int i = 0; i < 5; i++)
            {
                DrawCards.DrawCardSuitRank(sortedPlayerHand[i], x, y);
                x++;
            }
            y = 10;
            x = 0;
            Console.SetCursorPosition(x, 8);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("CPU's Hand");
            for(int i = 5; i < 10; i++)
            {
                DrawCards.DrawCardSuitRank(sortedCpuHand[i - 5], x, y);
                x++;
            }
        }

        public void EvaluateHands()
        {
            Console.ForegroundColor = ConsoleColor.White;

            HandEvaluator playerHandEval = new HandEvaluator(sortedPlayerHand);
            HandEvaluator cpuHandEval = new HandEvaluator(sortedCpuHand);

            Hand playerHand = playerHandEval.EvaluateHand();
            Hand cpuHand = cpuHandEval.EvaluateHand();

            Console.WriteLine("\n\nPlayer's Hand: " + playerHand);
            Console.WriteLine("CPU's Hand: " + cpuHand);

            if(playerHand > cpuHand)
            {
                Console.WriteLine("Player wins!");
            }
            else if(playerHand < cpuHand)
            {
                Console.WriteLine("Computer wins!");
            }
            else
            {
                if(playerHandEval.HandValues.Total > cpuHandEval.HandValues.Total)
                {
                    Console.WriteLine("Player wins!");
                }
                else if(playerHandEval.HandValues.Total < cpuHandEval.HandValues.Total)
                {
                    Console.WriteLine("Computer wins!");
                }
                else if(playerHandEval.HandValues.HighCard > cpuHandEval.HandValues.HighCard)
                {
                    Console.WriteLine("Player wins!");
                }
                else if (playerHandEval.HandValues.HighCard < cpuHandEval.HandValues.HighCard)
                {
                    Console.WriteLine("Computer wins!");
                }
                else
                {
                    Console.WriteLine("Draw!");
                }
            }

            Console.WriteLine();
        }
    }
}
