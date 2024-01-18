using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S00044234_BlackJAck
{
    internal class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public int GetValue()
        {
            if (Rank == "Ace")
                return 11;
            if (Rank == "King" || Rank == "Queen" || Rank == "Jack")
                return 10;

            return int.Parse(Rank);
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }

    internal class Deck
    {
        private List<Card> cards;
        private Random random;

        public Deck()
        {
            cards = new List<Card>();
            random = new Random();

            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    cards.Add(new Card { Suit = suit, Rank = rank });
                }
            }
        }
    }
    internal class Hand
    {
        protected List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public string GetHand()
        {
            return string.Join(", ", cards);
        }
    }

    internal class Player : Hand
    {
        public bool IsBusted()
        {
            return GetHandValue() > 21;
        }
    }


    internal class Dealer : Hand
    {
        public bool ShouldHit()
        {
            return GetHandValue() < 17;
        }

        public bool IsBusted()
        {
            return GetHandValue() > 21;
        }

        public string GetPartialHand()
        {
            return $"{cards[0]}, *";
        }

        public string GetLastCard()
        {
            return cards[cards.Count - 1].ToString();
        }


    }
}

      

    

