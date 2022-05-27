namespace Blackjack
{
    internal class Player : Person
    {
        private double TotalBalance { get; set; } = 100.00;

        public Player(string name) : base(name)
        {
            Name = name;
        }

        public void AddToTotalBalance(double value)
        {
            TotalBalance+= value;
        }

        public void SubtractFromTotalBalance(double value)
        {
            TotalBalance-= value;
        }

        public double GetTotalBalance()
        {
            return TotalBalance;
        }
    }
}
