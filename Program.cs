namespace MiniProjectBlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck.CreateDeck();

            //Shuffle and stack check for deck function PASS
            Deck.PrintDeck();
            Deck.ShuffleDeck();
            Console.WriteLine();
            Deck.PrintDeck();
            Console.WriteLine();
            Console.WriteLine(Deck.ShuffledCardDeck.Pop().CardName);
            Console.WriteLine(Deck.ShuffledCardDeck.Count);
            Console.WriteLine(Deck.ShuffledCardDeck.Pop().CardName);
            Console.WriteLine(Deck.ShuffledCardDeck.Count);

            Player player = new Player(); //New player  and Dealer
            Dealer dealer = new Dealer();

            //Player Check PASS
            player.AddToHand(Deck.ShuffledCardDeck.Pop());
            player.AddToHand(Deck.ShuffledCardDeck.Pop());
            player.AddToHand(Deck.ShuffledCardDeck.Pop());
            Console.WriteLine();
            Console.WriteLine();
            foreach (Card card in player.CurrentCards)
            {
                Console.WriteLine($"{card.CardName}");
            }
            Console.WriteLine();
            Console.WriteLine(Deck.ShuffledCardDeck.Count);

            //Dealer check PASS
            dealer.AddToHand(Deck.ShuffledCardDeck.Pop());
            dealer.AddToHand(Deck.ShuffledCardDeck.Pop());
            dealer.AddToHand(Deck.ShuffledCardDeck.Pop());
            Console.WriteLine();
            Console.WriteLine();
            foreach (Card card in dealer.CurrentCards)
            {
                Console.WriteLine($"{card.CardName}");
            }
            Console.WriteLine();
            Console.WriteLine(Deck.ShuffledCardDeck.Count);

            GameLoop.Run();
        }
    }
}
