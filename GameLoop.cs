using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectBlackJack
{
    /// <summary>
    /// FOR TOMORROW THE 10th, Get back to writing the hit or stay method 
    /// </summary>
    public class GameLoop
    {
        //Main gameloop
        public static void Run()
        {
            
            Console.WriteLine("WELCOME TO BLACKJACK!");
            while (StartOrEnd())
            {
                Deck.ShuffleDeck(); // Inital shuffle
                Player player = new Player(); //New player and Dealer Creation
                Dealer dealer = new Dealer();
                Deal(player, dealer);
                while (PlayerHitOrStay())
                {

                }
            }
            
        }

        //Initial choice to start or end program
        public static bool StartOrEnd()
        {
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
            player.CardValueSum += card.CardValue;
            Console.WriteLine($"First Card to player: {card.CardName}");

            Console.WriteLine();
            //Next is dealer hidden card
            card = Deck.ShuffledCardDeck.Pop();
            dealer.AddToHand(card);
            dealer.CardValueSum += card.CardValue;
            Console.WriteLine($"First Card to Dealer: HIDDEN");

            Console.WriteLine();
            //Next is player 2nd card
            card = Deck.ShuffledCardDeck.Pop();
            player.AddToHand(card);
            player.CardValueSum += card.CardValue;
            Console.WriteLine($"First Card to player: {card.CardName}");

            Console.WriteLine();
            //Last is dealer 2nd card show
            card = Deck.ShuffledCardDeck.Pop();
            dealer.AddToHand(card);
            dealer.CardValueSum += card.CardValue;
            Console.WriteLine($"First Card to Dealer: {card.CardName}");

            Console.WriteLine("<========== DEAL END ==========>");

            Console.WriteLine();
            //Print our current player cards and total
            Console.Write("Player hand total: ");
            player.PrintHand();
            Console.Write($"  =  {player.CardValueSum}");
            Console.WriteLine();
        }

        //Hit or stay choice of the game
        static bool PlayerHitOrStay()
        {
            Console.WriteLine();
            Console.WriteLine("Do you wish to HIT or STAY?");
            return false;
        }

    }

    

}
