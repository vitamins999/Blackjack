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
                DrawPile drawPile = new DrawPile(1);

                Console.WriteLine("Deal a new card? (y/n)\n");
                string dealNewCard = Console.ReadLine();

                if (dealNewCard.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                playerHand = AddCardToHand("Player", playerHand, drawPile);

                if (playerHand == 21)
                {
                    Console.WriteLine("Blackjack! You win!");
                    break;
                } else if (playerHand > 21)
                {
                    Console.WriteLine("Bust! You lose!");
                    break;
                }

                dealerHand = AddCardToHand("Dealer", dealerHand, drawPile);

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

        static int AddCardToHand(string handOwner, int handValue, DrawPile drawPile)
        {
            Card card = drawPile.DrawCard();
            Console.WriteLine($"\n{handOwner} draws {card.GetName()}");
            handValue += card.GetValue();
            Console.WriteLine($"{handOwner}'s hand: {handValue}");

            return handValue;
        }
    }
}
