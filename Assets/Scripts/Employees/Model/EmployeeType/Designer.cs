using static Employees.Configurations.DesignerConfiguration;

namespace Employees.Model
{
    public class Designer : Employee
    {
        public Designer(Seniority seniority, Salary salary = new()) : base(seniority, salary)
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