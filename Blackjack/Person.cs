namespace Blackjack
{
    internal class Person
    {
        public string Name;
        private int Score { get; set; } = 0;
        private int TotalHandValue { get; set; } = 0;

        public Person(string name)
        {
            Name = name;
        }

        public void AddWinToScore()
        {
            Score++;
        }

        public int GetScore()
        {
            return Score;
        }

        public void AddValueToHand(int value)
        {
            TotalHandValue += value;
        }

        public int GetTotalHandValue()
        {
            return TotalHandValue;
        }

        public void ResetTotalHandValue()
        {
            TotalHandValue = 0;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
