﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Player
    {
        private string name;
        private int score = 0;
        private int totalHandValue = 0;
        private double totalBalance = 100.00;

        public Player(string name)
        {
            this.name = name;
        }

        public void AddWinToScore()
        {
            score++;
        }

        public int GetScore()
        {
            return score;
        }

        public void AddValueToHand(int value)
        {
            totalHandValue+= value;
        }

        public int GetTotalHandValue()
        {
            return totalHandValue;
        }

        public void ResetTotalHandValue()
        {
            totalHandValue = 0;
        }

        public void AddToTotalBalance(double value)
        {
            totalBalance+= value;
        }

        public void SubtractFromTotalBalance(double value)
        {
            totalBalance-= value;
        }

        public double GetTotalBalance()
        {
            return totalBalance;
        }

        public string GetName()
        {
            return name;
        }
    }
}
