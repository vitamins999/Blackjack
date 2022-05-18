using System;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHand = 0;
            int dealerHand = 0;

            bool playerStand = false;
            string winner = "Draw";

            while (playerStand == false && dealerHand < 17)
            {
                DrawPile drawPile = new DrawPile(1);

                if (playerStand == false)
                {
                    Console.WriteLine("Deal a new card? (y/n)\n");
                    string dealNewCard = Console.ReadLine();

                    if (dealNewCard.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        playerHand = AddCardToHand("Player", playerHand, drawPile);

                        if (playerHand == 21)
                        {
                            Console.WriteLine("Blackjack!");
                            winner = "Player";
                            break;
                        }
                        else if (playerHand > 21)
                        {
                            Console.WriteLine("Bust!");
                            winner = "Dealer";
                            break;
                        }
                    }
                    else
                    {
                        playerStand = true;
                    }
                }

                if (dealerHand < 17)
                {
                    dealerHand = AddCardToHand("Dealer", dealerHand, drawPile);

                    if (dealerHand == 21)
                    {
                        Console.WriteLine("Blackjack!");
                        winner = "Dealer";
                        break;
                    }
                    else if (dealerHand > 21)
                    {
                        Console.WriteLine("Dealer bust!");
                        winner = "Player";
                        break;
                    }
                }
            }

            Console.WriteLine("\n**Final Scores**");
            Console.WriteLine($"\nPlayer: { playerHand }");
            Console.WriteLine($"\nDealer: {dealerHand}\n");

            if (playerHand > dealerHand && playerHand <= 21)
            {
                winner = "Player";
            } else if (dealerHand > playerHand && dealerHand <= 21)
            {
                winner = "Dealer";
            }

            if (winner.Equals("Player"))
            {
                Console.WriteLine("\nCongratulations! You win!");
            } else if (winner.Equals("Dealer"))
            {
                Console.WriteLine("\nToo bad! Dealer wins!");
            } else
            {
                Console.WriteLine("\nWell how about that? It's a draw!");
            }
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
