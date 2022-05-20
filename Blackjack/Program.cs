using System;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BLACKJACK!\n\n");

            string playerName = GetPlayerName();

            Player player = new Player(playerName);
            Player dealer = new Player("Dealer");

            int amountOfDecks = GetAmountOfDecks(player);
            PlayGame(player, dealer, amountOfDecks);
            ShowFinalScores(player, dealer);

            Console.WriteLine("\n\nPress any key to close...");
            Console.ReadKey();
        }

        static string GetPlayerName()
        {
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine().Trim();

            return playerName;
        }
        static int GetAmountOfDecks(Player player)
        {
            int amountOfDecksNumber = 0;
            bool isNumber = false;

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

            return amountOfDecksNumber;
        }

        static void PlayGame(Player player, Player dealer, int amountOfDecks)
        {
            bool keepPlaying = true;

            DrawPile drawPile = new DrawPile(amountOfDecks);
            Console.WriteLine("");

            while (keepPlaying)
            {
                PlayRound(drawPile, player, dealer);

                Console.WriteLine("\nKeep playing? (y/n)\n");
                keepPlaying = GetYesOrNoInput();

                Console.WriteLine("");
            }
        }

        static void PlayRound(DrawPile drawPile, Player player, Player dealer)
        {
            player.ResetTotalHandValue();
            dealer.ResetTotalHandValue();

            bool playerStand = false;
            bool quitGame = false;
            string winner;

            StartingHand(player, dealer, drawPile);
            winner = CheckIfStartingHandsWin(player, dealer);

            if (!winner.Equals("Draw"))
            {
                quitGame = true;
            }

            while (!quitGame)
            {

                if (playerStand == false)
                {
                    Console.WriteLine($"Deal you a new card, {player.GetName()}? (y/n)\n");
                    bool dealNewCard = GetYesOrNoInput();
                    Console.WriteLine("");

                    if (dealNewCard)
                    {
                        AddCardToHand(player, drawPile);

                        winner = CheckIfBlackjackOrBust(player, dealer);

                        if (!winner.Equals("Draw"))
                        {
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

                    winner = CheckIfBlackjackOrBust(dealer, player);

                    if (!winner.Equals("Draw"))
                    {
                        break;
                    }
                }

                if (playerStand && dealer.GetTotalHandValue() >= 17)
                {
                    quitGame = true;
                }
            }

            ShowFinalHands(player, dealer, winner);
        }

        static void StartingHand(Player player, Player dealer, DrawPile drawPile)
        {
            Console.WriteLine("***STARTING HANDS***");

            AddCardToHand(player, drawPile);
            AddCardToHand(dealer, drawPile);
            AddCardToHand(player, drawPile);
            AddCardToHand(dealer, drawPile);
        }
        static void AddCardToHand(Player player, DrawPile drawPile)
        {
            Card card = drawPile.DrawCard();
            Console.WriteLine($"{player.GetName()} draws {card.GetName()}");
            player.AddValueToHand(card.GetValue());
            Console.WriteLine($"{player.GetName()}'s hand: {player.GetTotalHandValue()}\n");
        }

        static string CheckIfStartingHandsWin(Player player, Player dealer)
        {
            string naturalBlackjackWinnerPlayer = CheckIfBlackjackOrBust(player, dealer);
            string naturalBlackjackWinnerDealer = CheckIfBlackjackOrBust(dealer, player);

            if (naturalBlackjackWinnerPlayer == dealer.GetName() && naturalBlackjackWinnerDealer == player.GetName())
            {
                return "DoubleBust";
            }
            else if (naturalBlackjackWinnerPlayer == player.GetName() && naturalBlackjackWinnerDealer == dealer.GetName())
            {
                return "StandOff";
            }
            else if (naturalBlackjackWinnerPlayer == player.GetName())
            {
                return player.GetName();
            }
            else if (naturalBlackjackWinnerDealer == dealer.GetName())
            {
                return dealer.GetName();
            }
            else
            {
                return "Draw";
            }
        }

        static string CheckIfBlackjackOrBust(Player playerToCheck, Player opponent)
        {
            if (playerToCheck.GetTotalHandValue() == 21)
            {
                Console.WriteLine("Blackjack!");
                return playerToCheck.GetName();
            }
            else if (playerToCheck.GetTotalHandValue() > 21)
            {
                Console.WriteLine("Bust!");
                return opponent.GetName();
            } else
            {
                return "Draw";
            }
        }

        static bool GetYesOrNoInput()
        {
            while (true)
            {
                string input = Console.ReadLine().Trim();

                if (input.Equals("y", StringComparison.OrdinalIgnoreCase) || input.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (input.Equals("n", StringComparison.OrdinalIgnoreCase) || input.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("\nPlease only answer 'yes', 'y', 'no', or 'n'.\n");
                    continue;
                }
            }
        }

        static void ShowFinalHands(Player player, Player dealer, string winner)
        {
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
            } else if (winner.Equals("StandOff")) 
            {
                Console.WriteLine("Stand Off! You both win!");
                player.AddWinToScore();
                dealer.AddWinToScore();
            } else if (winner.Equals("DoubleBust"))
            {
                Console.WriteLine("Double Bust! You both lose!");
            }
            else
            {
                Console.WriteLine("\nWell how about that? It's a draw!");
            }

            Console.WriteLine("");
        }

        static void ShowFinalScores(Player player, Player dealer)
        {
            Console.WriteLine("***FINAL SCORES***");
            Console.WriteLine($"\n{player.GetName()}: {player.GetScore()} win" + (player.GetScore() != 1 ? "s" : "") + ".");
            Console.WriteLine($"{dealer.GetName()}: {dealer.GetScore()} win" + (dealer.GetScore() != 1 ? "s" : "") + ".");
        }
    }
}
