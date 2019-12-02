using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public enum Hand
    {
        Nothing, OnePair, TwoPairs, ThreeKind, Straight, Flush,
        FullHouse, FourKind
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    class HandEvaluator : Card
    {
        private int heartSum;
        private int diamondSum;
        private int clubSum;
        private int spadeSum;
        private Card[] cards;
        private HandValue handValue;

        public HandEvaluator(Card[] sortedHand)
        {
            heartSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadeSum = 0;
            cards = new Card[5];
            Cards = sortedHand;
            handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }

        public Hand EvaluateHand()
        {
            // get suit of hand
            GetSuitNum();
            if (FourOfKind())
            {
                return Hand.FourKind;
            }
            else if (FullHouse())
            {
                return Hand.FullHouse;
            }
            else if (Flush())
            {
                return Hand.Flush;
            }
            else if (Straight())
            {
                return Hand.Straight;
            }
            else if (ThreeOfKind())
            {
                return Hand.ThreeKind;
            }
            else if (TwoPairs())
            {
                return Hand.TwoPairs;
            }
            else if (OnePair())
            {
                return Hand.OnePair;
            }

            // none of the above get high card value
            handValue.HighCard = (int)cards[4].Rank;
            return Hand.Nothing;
        }

        private void GetSuitNum()
        {
            foreach (var element in Cards)
            {
                if (element.Suit == Card.SUIT.HEARTS)
                {
                    heartSum++;
                }
                else if (element.Suit == Card.SUIT.DIAMONDS)
                {
                    diamondSum++;
                }
                else if (element.Suit == Card.SUIT.CLUBS)
                {
                    clubSum++;
                }
                else if (element.Suit == Card.SUIT.SPADES)
                {
                    spadeSum++;
                }
            }
        }

        private bool FourOfKind()
        {
            if (cards[0].Rank == cards[1].Rank &&
                cards[0].Rank == cards[2].Rank &&
                cards[0].Rank == cards[3].Rank)
            {
                handValue.Total = (int)cards[1].Rank * 4;
                handValue.HighCard = (int)cards[4].Rank;
                return true;
            }
            else if (cards[1].Rank == cards[2].Rank &&
                cards[1].Rank == cards[3].Rank &&
                cards[1].Rank == cards[4].Rank)
            {
                handValue.Total = (int)cards[1].Rank * 4;
                handValue.HighCard = (int)cards[0].Rank;
                return true;
            }

            return false;
        }

        private bool FullHouse()
        {
            if ((cards[0].Rank == cards[1].Rank &&
                cards[0].Rank == cards[2].Rank &&
                cards[3].Rank == cards[4].Rank) ||
                (cards[0].Rank == cards[1].Rank &&
                cards[2].Rank == cards[3].Rank &&
                cards[2].Rank == cards[4].Rank))
            {
                handValue.Total = (int)(cards[0].Rank) +
                    (int)(cards[1].Rank) +
                    (int)(cards[2].Rank) +
                    (int)(cards[3].Rank) +
                    (int)(cards[4].Rank);
                return true;
            }
            return false;
        }

        private bool Flush()
        {
            if (heartSum == 5 || diamondSum == 5 ||
                clubSum == 5 || spadeSum == 5)
            {
                handValue.Total = (int)cards[4].Rank;
                return true;
            }
            return false;
        }

        private bool Straight()
        {
            if(cards[0].Rank + 1 == cards[1].Rank &&
                cards[1].Rank + 1 == cards[2].Rank &&
                cards[2].Rank + 1 == cards[3].Rank &&
                cards[3].Rank + 1 == cards[4].Rank)
            {
                handValue.Total = (int)cards[4].Rank;
                return true;
            }
            return false;
        }

        private bool ThreeOfKind()
        {
            if((cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank) ||
                (cards[1].Rank == cards[2].Rank && cards[1].Rank == cards[3].Rank))
            {
                handValue.Total = (int)cards[2].Rank * 3;
                handValue.HighCard = (int)cards[4].Rank;
                return true;
            }
            else if(cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank)
            {
                handValue.Total = (int)cards[2].Rank * 3;
                handValue.HighCard = (int)cards[1].Rank;
                return true;
            }
            return false;
        }

        private bool TwoPairs()
        {
            if(cards[0].Rank == cards[1].Rank && cards[2].Rank == cards[3].Rank)
            {
                handValue.Total = ((int)cards[1].Rank * 2) + ((int)cards[3].Rank * 2);
                handValue.HighCard = (int)cards[4].Rank;
                return true;
            }
            else if(cards[0].Rank == cards[1].Rank && cards[3].Rank == cards[4].Rank)
            {
                handValue.Total = ((int)cards[1].Rank * 2) + ((int)cards[3].Rank * 2);
                handValue.HighCard = (int)cards[2].Rank;
                return true;
            }
            else if(cards[1].Rank == cards[2].Rank && cards[3].Rank == cards[4].Rank)
            {
                handValue.Total = ((int)cards[1].Rank * 2) + ((int)cards[3].Rank * 2);
                handValue.HighCard = (int)cards[0].Rank;
                return true;
            }
            return false;
        }

        private bool OnePair()
        {
            if(cards[0].Rank == cards[1].Rank)
            {
                handValue.Total = (int)cards[0].Rank * 2;
                handValue.HighCard = (int)cards[4].Rank;
                return true;
            }
            else if(cards[1].Rank == cards[2].Rank)
            {
                handValue.Total = (int)cards[1].Rank * 2;
                handValue.HighCard = (int)cards[4].Rank;
                return true;
            }
            else if (cards[2].Rank == cards[3].Rank)
            {
                handValue.Total = (int)cards[2].Rank * 2;
                handValue.HighCard = (int)cards[4].Rank;
                return true;
            }
            else if (cards[3].Rank == cards[4].Rank)
            {
                handValue.Total = (int)cards[3].Rank * 2;
                handValue.HighCard = (int)cards[2].Rank;
                return true;
            }
            return false;
        }
    } // END OF HandEvaluator class
}
