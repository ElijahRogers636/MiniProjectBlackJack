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
    /// FOR TOMORROW Add and method to check who wins, Fix the recursion issue(Outputs stack when game restarts by recursion and player exits manually)
    /// </summary>
    public class GameLoop
    {
        //Main gameloop
        public static void Run()
        {
            bool continueGame = StartOrEnd(); //Initial start
            while (continueGame)
            {
                Deck.ShuffleDeck(); // Inital shuffle
                Player player = new Player(); //New player and Dealer Creation
                Dealer dealer = new Dealer();
                Deal(player, dealer); // Deals initial cards, sets hands, calulates totals, prints hands
                if (PlayerHitOrStay(player) || DealerHitOrStay(dealer)) // User choice to hit or stay, updates player and dealer hand and total accordingly, end if player busts
                {
                    continueGame = false;
                }
                else
                {
                    EndGameCheck(player, dealer); //Final check to see who wins or if it is a tie
                }
                continueGame = StartOrEnd(); //Continue or exit

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
            Console.WriteLine("<=========================DEAL CARDS START<=========================>");
            Console.WriteLine();

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

            Console.WriteLine();
            Console.WriteLine("<=========================DEAL CARDS END<=========================>");
            Console.WriteLine();

        }

        //Hit or stay choice of the game for player
        static bool PlayerHitOrStay(Player player)
        {
            Console.WriteLine("<=========================PLAYER TURN START<=========================>");
            Console.WriteLine();

            //Print our current player cards and total
            Console.Write("Player hand total: ");
            player.PrintHand();
            Console.Write($"  =  {player.CardValueSum}");
            Console.WriteLine();

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
            Console.WriteLine();
            Console.WriteLine("<=========================PLAYER TURN END<=========================>");
            Console.WriteLine();
            return false;
            
        }
        
        //Reveal dealer hidden card and hit if total is below 17 and stay if 17 or greater
        static bool DealerHitOrStay(Dealer dealer)
        {
            Console.WriteLine("<=========================DEALER TURN START<=========================>");
            Console.WriteLine();
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
                    Console.WriteLine($"Dealer Stays with a total of: {dealer.CardValueSum}");
                    Console.WriteLine();
                    whileChoice = false;
                }
            }
            Console.WriteLine();
            Console.WriteLine("<=========================DEALER TURN END<=========================>");
            Console.WriteLine();
            return false;
        }

        //Final check to see who wins or if it is a tie
        static void EndGameCheck(Player player, Dealer dealer)
        {
            int dealerTotal = dealer.CardValueSum;
            int playerTotal = player.CardValueSum;
            Console.WriteLine("<=========================WHO WINS<=========================>");
            Console.WriteLine();
            Console.WriteLine($"Player Total: {playerTotal}");
            Console.WriteLine();
            Console.WriteLine($"Dealer Total: {dealerTotal}");
            Console.WriteLine();

            if (dealerTotal == playerTotal)
            {
                Console.WriteLine($"TIE Dealer Total: {dealerTotal} = Player Total: {playerTotal}");
            }
            else if (dealerTotal > playerTotal)
            {
                Console.WriteLine($"Dealer Wins! Dealer Total: {dealerTotal} <- Player Total: {playerTotal}");
            }
            else
            {
                Console.WriteLine($"Player Wins! Dealer Total: {dealerTotal} -> Player Total: {playerTotal}");
            }
            Console.WriteLine();
            Console.WriteLine("<=========================GAME END<=========================>");
            Console.WriteLine();
        }

    }

}
