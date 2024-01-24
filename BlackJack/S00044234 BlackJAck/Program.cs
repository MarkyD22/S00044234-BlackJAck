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

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
        static void PlayerTurn(Player player, Deck deck)
        {
            while (true)
            {
                Console.Write("Do you want to stick or twist? (s/t): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "s")
                {
                    player.AddCard(deck.DealCard());
                    Console.WriteLine($"Your hand: {player.GetHand()} ({player.GetHandValue()})");

                    if (player.IsBusted())
                    {
                        Console.WriteLine("Busted! You lose.");
                        break;
                    }
                }
                else if (choice == "t")
                {
                    break;
                }
            }
        }

        public  Card DealCard()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("No cards left in the deck.");

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        static void DealerTurn(Dealer dealer, Deck deck)
        {
            Console.WriteLine($"\nDealer's hand: {dealer.GetHand()} ({dealer.GetHandValue()})");

            while (dealer.ShouldHit())
            {
                dealer.AddCard(deck.DealCard());
                Console.WriteLine($"Dealer hits: {dealer.GetLastCard()}");
                Console.WriteLine($"Dealer's hand: {dealer.GetHand()} ({dealer.GetHandValue()})");
            }

            if (dealer.IsBusted())
                Console.WriteLine("Dealer busted!");
        }

        static void DetermineWinner(Player player, Dealer dealer)
        {
            Console.WriteLine($"\nYour hand: {player.GetHand()} ({player.GetHandValue()})");
            Console.WriteLine($"Dealer's hand: {dealer.GetHand()} ({dealer.GetHandValue()})");

            if (player.IsBusted() || (!dealer.IsBusted() && dealer.GetHandValue() >= player.GetHandValue()))
                Console.WriteLine("Dealer wins!");
            else
                Console.WriteLine("You win!");
        }
    }




