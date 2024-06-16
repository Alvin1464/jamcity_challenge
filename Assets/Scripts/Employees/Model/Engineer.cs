using System;
using static Employees.Configurations.EngineerConfiguration;

namespace Employees.Model
{
    public class Engineer : Employee
    {
        public Engineer(Seniority seniority) : base(seniority, GetBaseSalary(seniority))
        {
        }

        public void ApplySalaryIncrement()
        {
            var newAmount = salary.Amount * GetSalaryIncrementPercentage(seniority) * 0.01f + salary.Amount;
            salary = new Salary(newAmount, salary.SalaryCurrency);
        }
    }
}