using System;
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

        public string GetName()
        {
            return name;
        }
    }
}
