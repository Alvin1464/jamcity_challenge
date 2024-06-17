using static Employees.Configurations.CeoConfiguration;
using static Employees.Model.Seniority;

namespace Employees.Model
{
    public class Ceo : Employee
    {
        public Ceo(Salary salary = new()) : base(Senior, salary)
        {
        }

        public void AssignBaseSalary() => 
            salary = GetBaseSalary(seniority);
        
        public void ApplySalaryIncrement()
        {
            var newAmount = salary.Amount * GetSalaryIncrementPercentage(seniority) * 0.01f + salary.Amount;
            salary = new Salary(newAmount, salary.SalaryCurrency);
        }
    }
}