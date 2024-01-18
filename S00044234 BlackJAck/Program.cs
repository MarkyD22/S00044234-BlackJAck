using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace S00044234_BlackJAck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack!");

            while (true)
            {
                // Initialize and shuffle deck
                Deck deck = new Deck();
                deck.Shuffle();

                // Initialize players
                Player player = new Player();
                Dealer dealer = new Dealer();

                // Deal initial cards
                player.AddCard(deck.DealCard());
                dealer.AddCard(deck.DealCard());
                player.AddCard(deck.DealCard());
                dealer.AddCard(deck.DealCard());

                // Display initial hands
                Console.WriteLine($"Your hand: {player.GetHand()} ({player.GetHandValue()})");
                Console.WriteLine($"Dealer's hand: {dealer.GetPartialHand()}");

                // Player's turn
                PlayerTurn(player, deck);

                // Dealer's turn
                DealerTurn(dealer, deck);

                // Determine the winner
                DetermineWinner(player, dealer);

                // Ask if the player wants to play again
                Console.Write("\nDo you want to play again? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                    break;

                Console.Clear();
            }

            Console.WriteLine("Thanks for playing Blackjack!");
        }

        public Card DealCard()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("No cards left in the deck.");

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;

        }
        public int GetHandValue()
        {
            int value = 0;
            int aceCount = 0;

            foreach (Card card in cards)
            {
                value += card.GetValue();

                if (card.Rank == "Ace")
                    aceCount++;
            }

            while (aceCount > 0 && value > 21)
            {
                value -= 10;
                aceCount--;
            }

            return value;
        }

