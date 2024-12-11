using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectBlackJack
{
    /// <summary>
    /// FOR TOMORROW make sure you make a loss case for if the player busts during the player hit/stay method
    /// </summary>
    public class GameLoop
    {
        //Main gameloop
        public static void Run()
        {
            while (StartOrEnd())
            {
                Deck.ShuffleDeck(); // Inital shuffle
                Player player = new Player(); //New player and Dealer Creation
                Dealer dealer = new Dealer();
                Deal(player, dealer); // Deals initial cards, sets hands, calulates totals, prints hands
                if (PlayerHitOrStay(player)) // User choice to hit or stay, updates player hand and total accordingly
                {
                    Run(); // If true, recursivly call Run() to restart game
                }
                if (DealerHitOrStay(dealer))// Reveals dealer's hand, hits or stays based on total
                {
                    Run();
                }

            }
            
        }

        //Initial choice to start or end program
        public static bool StartOrEnd()
        {
            Console.WriteLine();
            Console.WriteLine("WELCOME TO BLACKJACK!");
            Console.WriteLine("Would you like to start a game or Exit the program?");
            Console.WriteLine();
            Console.WriteLine("Type BEGIN to sart and new game    OR    EXIT to exit the program");
            Console.Write("Choice: ");
            string choice = Console.ReadLine().Trim().ToLower();
            Console.WriteLine();

            if (choice == "begin")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        // Player and Dealer(Expand to add more players if want)
        public static void Deal(Player player, Dealer dealer)
        {
            Console.WriteLine("<========== DEAL START ==========>");

            // First card goes to player
            Card card = Deck.ShuffledCardDeck.Pop();
            player.AddToHand(card);
            Console.WriteLine($"First Card to player: {card.CardName}");

            Console.WriteLine();
            //Next is dealer hidden card
            card = Deck.ShuffledCardDeck.Pop();
            dealer.AddToHand(card);
            Console.WriteLine($"First Card to Dealer: HIDDEN");

            Console.WriteLine();
            //Next is player 2nd card
            card = Deck.ShuffledCardDeck.Pop();
            player.AddToHand(card);
            Console.WriteLine($"Second Card to player: {card.CardName}");

            Console.WriteLine();
            //Last is dealer 2nd card show
            card = Deck.ShuffledCardDeck.Pop();
            dealer.AddToHand(card);
            Console.WriteLine($"Second Card to Dealer: {card.CardName}");

            Console.WriteLine("<========== DEAL END ==========>");

            Console.WriteLine();
            //Print our current player cards and total
            Console.Write("Player hand total: ");
            player.PrintHand();
            Console.Write($"  =  {player.CardValueSum}");
            Console.WriteLine();
        }

        //Hit or stay choice of the game for player
        static bool PlayerHitOrStay(Player player)
        {
            bool whileChoice = true;
            while (whileChoice)
            {
                Console.WriteLine();
                Console.WriteLine("Do you wish to HIT or STAY?");
                Console.WriteLine();
                Console.Write("Enter Here:");
                string choice = Console.ReadLine().Trim().ToLower();
                Console.WriteLine();

                if (choice == "hit")
                {
                    // Give the player a new card
                    Card card = Deck.ShuffledCardDeck.Pop();
                    player.AddToHand(card);
                    Console.WriteLine($"New Card to player: {card.CardName}");

                    Console.WriteLine();
                    //Print our current player cards and total
                    Console.Write("Player hand total: ");
                    player.PrintHand();
                    Console.Write($"  =  {player.CardValueSum}");
                    Console.WriteLine();

                    if (player.CardValueSum > 21)
                    {
                        Console.WriteLine();
                        Console.WriteLine("BUST, Dealer wins! PLayer Loses!");
                        Console.WriteLine();
                        return true;
                    }
                }
                else
                {
                    whileChoice = false;
                }
            }
            return false;
            
        }
        
        //Reveal dealer hidden card and hit if total is below 17 and stay if 17 or greater
        static bool DealerHitOrStay(Dealer dealer)
        {
            // Reveal Dealer cards
            Console.Write("Dealer Reveals Hand: ");
            dealer.PrintHand();
            Console.WriteLine();

            bool whileChoice = true;
            while (whileChoice)
            {
                // If dealer card values are less than 17 he must hit else stay
                if (dealer.CardValueSum < 17)
                {
                    Card card = Deck.ShuffledCardDeck.Pop();
                    Console.WriteLine();
                    Console.WriteLine("Dealer Has Less Than 17, He draws another card");
                    dealer.AddToHand(card);
                    Console.WriteLine();
                    Console.Write("Dealer hand total: ");
                    dealer.PrintHand();
                    Console.Write($"  =  {dealer.CardValueSum}");
                    Console.WriteLine();
                    if (dealer.CardValueSum > 21)
                    {
                        Console.WriteLine();
                        Console.WriteLine("BUST, Player wins! Dealer Loses!");
                        Console.WriteLine();
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Dealer hand total: ");
                    dealer.PrintHand();
                    Console.Write($"  =  {dealer.CardValueSum}");
                    Console.WriteLine();
                    whileChoice = false;
                }
            }
            return false;
        }

    }

}
