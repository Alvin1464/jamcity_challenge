using static Employees.Configurations.ProjectManagerConfiguration;

namespace Employees.Model
{
    public class ProjectManager : Employee
    {
        public ProjectManager(Seniority seniority) : base(seniority, GetBaseSalary(seniority))
        {
        }

        public void ApplySalaryIncrement()
        {
            var newAmount = salary.Amount * GetSalaryIncrementPercentage(seniority) * 0.01f + salary.Amount;
            salary = new Salary(newAmount, salary.SalaryCurrency);
        }
    }
}