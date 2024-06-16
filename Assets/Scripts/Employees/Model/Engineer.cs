using System;
using static Employees.Model.Currency;

namespace Employees.Model
{
    public class Engineer : Employee
    {
        static readonly Salary juniorBaseSalary = new(1500, DOLLARS);
        static readonly Salary semiSeniorBaseSalary = new(3000, DOLLARS);
        static readonly Salary seniorBaseSalary = new(5000, DOLLARS);
        static readonly float juniorSalaryIncrementPercentage = 5f;
        static readonly float semiSeniorSalaryIncrementPercentage = 7f;
        static readonly float seniorSalaryIncrementPercentage = 10f;
        
        public Engineer(Seniority seniority) : base(seniority, getBaseSalary(seniority))
        {
        }

        public void ApplySalaryIncrement()
        {
            var newAmount = salary.Amount * getSalaryIncrementPercentage(seniority) * 0.01f + salary.Amount;
            salary = new Salary(newAmount, salary.SalaryCurrency);
        }

        float getSalaryIncrementPercentage(Seniority seniority) =>
            seniority switch
            {
                Seniority.Junior => juniorSalaryIncrementPercentage,
                Seniority.Semi_Senior => semiSeniorSalaryIncrementPercentage,
                Seniority.Senior => seniorSalaryIncrementPercentage,
                _ => 0f
            };

        static Salary getBaseSalary(Seniority seniority) =>
            seniority switch
            {
                Seniority.Junior => juniorBaseSalary,
                Seniority.Semi_Senior => semiSeniorBaseSalary,
                Seniority.Senior => seniorBaseSalary,
                _ => new Salary()
            };
    }
}