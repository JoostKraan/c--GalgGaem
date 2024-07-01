namespace Kaartspel
{
    public class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            newDeck.currentCard = newDeck.PullRandomCard();

            for (int i = 0; i < newDeck.cards.Count; i++)
            {
                DisplayQuestion(newDeck.PullRandomCard(), newDeck);
            }
        }
        static void DisplayQuestion(Card cardInQuestion, Deck playerDeck)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"Your points: {playerDeck.GetPoints()}");
            Console.WriteLine($"Current card value is: {playerDeck.currentCard.cardIndex}");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Higher or Lower?");
            Console.Write("Guess: ");
            string guess = Console.ReadLine();
            Card randomCard = playerDeck.PullRandomCard();

            bool guessedRight = false;
            if (guess.ToLower() == "higher" && randomCard.cardIndex > playerDeck.currentCard.cardIndex)
            {
                playerDeck.AddPoints(10);
                guessedRight = true;
            }

            if (guess.ToLower() == "lower" && randomCard.cardIndex < playerDeck.currentCard.cardIndex)
            {
                playerDeck.AddPoints(10);
                guessedRight = true;
            }

            if (!guessedRight)
            {
                playerDeck.SetPoints(0);
            }
            playerDeck.currentCard = randomCard;
            Console.WriteLine("--------------------------------------------------------------");
        }
    }
}