using static Employees.Configurations.HumanResourcesConfiguration;

namespace Employees.Model
{
    public class HumanResources : Employee
    {
        public HumanResources(Seniority seniority) : base(seniority, GetBaseSalary(seniority))
        {
        }

        public void ApplySalaryIncrement()
        {
            var newAmount = salary.Amount * GetSalaryIncrementPercentage(seniority) * 0.01f + salary.Amount;
            salary = new Salary(newAmount, salary.SalaryCurrency);
        }
    }
}