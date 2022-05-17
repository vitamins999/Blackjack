using System;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHand = 0;
            int dealerHand = 0;

            while (true)
            {
                Console.WriteLine("Deal a new card? (y/n)\n");
                string dealNewCard = Console.ReadLine();

                if (dealNewCard.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                Random rand = new Random();

                int playerCard = rand.Next(2, 11);
                Console.WriteLine($"\nYou draw {playerCard}");

                playerHand += playerCard;
                Console.WriteLine($"Player's hand: {playerHand}");

                if (playerHand == 21)
                {
                    Console.WriteLine("Blackjack! You win!");
                    break;
                } else if (playerHand > 21)
                {
                    Console.WriteLine("Bust! You lose!");
                    break;
                }

                int dealerCard = rand.Next(2, 11);
                Console.WriteLine($"\nDealer draws {dealerCard}");

                dealerHand += dealerCard;
                Console.WriteLine($"Dealer's hand: {dealerHand}.\n");

                if (dealerHand == 21)
                {
                    Console.WriteLine("Blackjack! You lose!");
                    break;
                } else if (dealerHand > 21)
                {
                    Console.WriteLine("Dealer bust! You win!");
                    break;
                }
            }

            Console.WriteLine("\nGame over.  And yes, I know that's not how blackjack works. This is just to have a basic gameplay loop that will be made better.");
        }
    }
}
