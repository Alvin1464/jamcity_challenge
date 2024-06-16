using static Employees.Model.Currency;

namespace Employees.Model
{
    public struct Salary
    {
        public float Amount { get; private set; }
        public Currency SalaryCurrency { get; private set; }

        public Salary(float amount = 0, Currency currency = DOLLARS)
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