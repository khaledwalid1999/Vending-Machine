namespace Vending_Machine
{
    enum UserType
    {
        Customer = 1,
        Admin = 2
    }
    internal class User
    {
        public double Money { get; set; }
        internal UserType UserType { get; set; }

        public double AddMoney(double Amount)
        {
            Money += Amount;
            return Money;
        }

        public double GetCredit()
        {
            return Money;
        }
        public double ReturnChange()
        {
            double change = Money;
            Money = 0;
            return change;
        }
    }
}
