using System;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string amountOfDecksString;
            bool isNumber = false;
            int amountOfDecksNumber = 0;
            bool keepPlaying = true;

            Console.WriteLine("Welcome to BLACKJACK!\n\n");

            while (!isNumber || amountOfDecksNumber <= 0)
            {
                Console.WriteLine("How many decks would you like to play with?\n");
                amountOfDecksString = Console.ReadLine();

                isNumber = int.TryParse(amountOfDecksString, out amountOfDecksNumber);

                if (!isNumber || amountOfDecksNumber <= 0)
                {
                    Console.WriteLine($"{amountOfDecksString} is not a valid number! Please type in a whole number and try again.\n");
                }
            }
            
            DrawPile drawPile = new DrawPile(amountOfDecksNumber);
            Console.WriteLine("");

            while (keepPlaying)
            {
                drawPile = PlayGame(drawPile);

                Console.WriteLine("\nKeep playing? (y/n)\n");
                string keepPlayingString = Console.ReadLine().Trim();

                keepPlaying = keepPlayingString.Equals("y", StringComparison.OrdinalIgnoreCase);
                Console.WriteLine("");
            }

            Console.WriteLine("Thanks for playing!");
        }

        static DrawPile PlayGame(DrawPile drawPile)
        {
            int playerHand = 0;
            int dealerHand = 0;

            bool playerStand = false;
            bool quitGame = false;
            string winner = "Draw";

            while (!quitGame)
            {

                if (playerStand == false)
                {
                    Console.WriteLine("Deal you a new card? (y/n)\n");
                    string dealNewCard = Console.ReadLine().Trim();

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

                if (playerStand && dealerHand >= 17)
                {
                    quitGame = true;
                }
            }

            Console.WriteLine("\n**Final Scores**");
            Console.WriteLine($"\nPlayer: {playerHand}");
            Console.WriteLine($"\nDealer: {dealerHand}\n");

            if (playerHand > dealerHand && playerHand <= 21)
            {
                winner = "Player";
            }
            else if (dealerHand > playerHand && dealerHand <= 21)
            {
                winner = "Dealer";
            }

            if (winner.Equals("Player"))
            {
                Console.WriteLine("\nCongratulations! You win!");
            }
            else if (winner.Equals("Dealer"))
            {
                Console.WriteLine("\nToo bad! Dealer wins!");
            }
            else
            {
                Console.WriteLine("\nWell how about that? It's a draw!");
            }

            Console.WriteLine("");

            return drawPile;
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
