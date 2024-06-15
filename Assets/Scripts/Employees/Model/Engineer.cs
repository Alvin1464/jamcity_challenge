using System;
using static Employees.Model.Currency;

namespace Employees.Model
{
    public class Engineer : Employee
    {
        static readonly Salary juniorBaseSalary = new Salary(1500, DOLLARS);
        static readonly Salary semiSeniorBaseSalary = new Salary(3000, DOLLARS);
        static readonly Salary seniorBaseSalary = new Salary(5000, DOLLARS);
        
        public Engineer(Seniority seniority) : base(seniority, calculateBaseSalary(seniority))
        {
        }

        static Salary calculateBaseSalary(Seniority seniority) =>
            seniority switch
            {
                Seniority.Junior => juniorBaseSalary,
                Seniority.Semi_Senior => semiSeniorBaseSalary,
                Seniority.Senior => seniorBaseSalary,
                _ => new Salary()
            };
    }
}