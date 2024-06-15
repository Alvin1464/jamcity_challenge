using static Employees.Model.Currency;

namespace Employees.Model
{
    public struct Salary
    {
        public int Amount { get; private set; }
        public Currency SalaryCurrency { get; private set; }

        public Salary(int amount = 0, Currency currency = DOLLARS)
        {
            Amount = amount;
            SalaryCurrency = currency;
        }
    }

    public enum Currency
    {
        DOLLARS
    }
}