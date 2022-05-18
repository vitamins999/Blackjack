using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Card
    {
        private string name;
        private string suite;
        private int value;
        
        public Card(string name, string suite, int value)
        {
            this.name = name;
            this.suite = suite;
            this.value = value;
        }

        public string GetName()
        {
            return $"{name} of {suite}";
        }

        public int GetValue()
        {
            return value;
        }
    }
}
