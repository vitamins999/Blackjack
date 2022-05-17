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

                playerHand = addCardToHand("Player", playerHand);

                if (playerHand == 21)
                {
                    Console.WriteLine("Blackjack! You win!");
                    break;
                } else if (playerHand > 21)
                {
                    Console.WriteLine("Bust! You lose!");
                    break;
                }

                dealerHand = addCardToHand("Dealer", dealerHand);

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

        static int dealNewCard()
        {
            Random rand = new Random();
            int card = rand.Next(1, 11);
            return card;
        }

        static int addCardToHand(string handOwner, int handValue)
        {
            int card = dealNewCard();
            Console.WriteLine($"\n{handOwner} draws {card}");
            handValue += card;
            Console.WriteLine($"{handOwner}'s hand: {handValue}");

            return handValue;
        }
    }
}
