using System;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfDecksNumber = 0;

            bool isNumber = false;
            bool keepPlaying = true;

            Console.WriteLine("Welcome to BLACKJACK!\n\n");

            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();

            Player player = new Player(playerName);
            Player dealer = new Player("Dealer");

            while (!isNumber || amountOfDecksNumber <= 0)
            {
                Console.WriteLine($"\nHow many decks would you like to play with, {player.GetName()}?\n");
                string amountOfDecksString = Console.ReadLine();

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
                PlayRound(drawPile, player, dealer);

                Console.WriteLine("\nKeep playing? (y/n)\n");
                string keepPlayingString = Console.ReadLine().Trim();

                keepPlaying = keepPlayingString.Equals("y", StringComparison.OrdinalIgnoreCase);
                Console.WriteLine("");
            }

            Console.WriteLine("***FINAL SCORES***");
            Console.WriteLine($"\n{player.GetName()}: {player.GetScore()} win" + (player.GetScore() != 1 ? "s" : "") + ".");
            Console.WriteLine($"{dealer.GetName()}: {dealer.GetScore()} win" + (dealer.GetScore() != 1 ? "s" : "") + ".");

            Console.WriteLine($"\nThanks for playing, {player.GetName()}!");
        }

        static void PlayRound(DrawPile drawPile, Player player, Player dealer)
        {
            player.ResetTotalHandValue();
            dealer.ResetTotalHandValue();

            bool playerStand = false;
            bool quitGame = false;
            string winner = "Draw";

            while (!quitGame)
            {

                if (playerStand == false)
                {
                    Console.WriteLine($"Deal you a new card, {player.GetName()}? (y/n)\n");
                    string dealNewCard = Console.ReadLine().Trim();
                    Console.WriteLine("");

                    if (dealNewCard.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        AddCardToHand(player, drawPile);

                        if (player.GetTotalHandValue() == 21)
                        {
                            Console.WriteLine("Blackjack!");
                            winner = player.GetName();
                            break;
                        }
                        else if (player.GetTotalHandValue() > 21)
                        {
                            Console.WriteLine("Bust!");
                            winner = dealer.GetName();
                            break;
                        }
                    }
                    else
                    {
                        playerStand = true;
                    }
                }

                if (dealer.GetTotalHandValue() < 17)
                {
                    AddCardToHand(dealer, drawPile);

                    if (dealer.GetTotalHandValue() == 21)
                    {
                        Console.WriteLine("Blackjack!");
                        winner = dealer.GetName();
                        break;
                    }
                    else if (dealer.GetTotalHandValue() > 21)
                    {
                        Console.WriteLine($"{dealer.GetName()} bust!");
                        winner = player.GetName();
                        break;
                    }
                }

                if (playerStand && dealer.GetTotalHandValue() >= 17)
                {
                    quitGame = true;
                }
            }

            Console.WriteLine("\n***FINAL HANDS***");
            Console.WriteLine($"\n{player.GetName()}: {player.GetTotalHandValue()}");
            Console.WriteLine($"{dealer.GetName()}: {dealer.GetTotalHandValue()}\n");

            if (player.GetTotalHandValue() > dealer.GetTotalHandValue() && player.GetTotalHandValue() <= 21)
            {
                winner = player.GetName();
            }
            else if (dealer.GetTotalHandValue() > player.GetTotalHandValue() && dealer.GetTotalHandValue() <= 21)
            {
                winner = dealer.GetName();
            }

            if (winner.Equals(player.GetName()))
            {
                Console.WriteLine($"\nCongratulations, {player.GetName()}! You win!");
                player.AddWinToScore();
            }
            else if (winner.Equals(dealer.GetName()))
            {
                Console.WriteLine($"\nToo bad, {player.GetName()}! {dealer.GetName()} wins!");
                dealer.AddWinToScore();
            }
            else
            {
                Console.WriteLine("\nWell how about that? It's a draw!");
            }

            Console.WriteLine("");
        }

        static void AddCardToHand(Player player, DrawPile drawPile)
        {
            Card card = drawPile.DrawCard();
            Console.WriteLine($"{player.GetName()} draws {card.GetName()}");
            player.AddValueToHand(card.GetValue());
            Console.WriteLine($"{player.GetName()}'s hand: {player.GetTotalHandValue()}\n");
        }
    }
}
