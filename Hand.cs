using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectBlackJack
{
    public class Hand
    {
        public int CardValueSum { get; set; }
        public List<Card> CurrentCards {  get; set; } = new List<Card>();

        //Method to add to the array or list that represents a hand of card values
        public void AddToHand(Card card)
        {
            CurrentCards.Add(card);
        }

        // Prints the current hand for a dealer or player
        public void PrintHand()
        {
            Console.Write(" | ");
            foreach (Card card in CurrentCards)
            {
                Console.Write(card.CardName);
                Console.Write(" | ");
            }
        }
    }

    
}
