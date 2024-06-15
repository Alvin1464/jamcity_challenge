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

        static Salary calculateBaseSalary(Seniority seniority)
        {
            switch (seniority)
            {
                case Seniority.Junior:
                    return juniorBaseSalary;
                case Seniority.Semi_Senior:
                    return semiSeniorBaseSalary;
                case Seniority.Senior:
                    return seniorBaseSalary;
                default:
                    return new Salary();
            }
        }
    }
}