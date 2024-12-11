namespace MiniProjectBlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck.CreateDeck(); // Deck creation
            GameLoop.Run(); // Runs the content of the game      
        }
    }
}
