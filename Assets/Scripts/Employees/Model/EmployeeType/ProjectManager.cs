using static Employees.Configurations.ProjectManagerConfiguration;

namespace Employees.Model.EmployeeType
{
    public class ProjectManager : Employee
    {
        public ProjectManager(Seniority seniority, Salary salary = new()) : base(seniority, salary)
        {
        }
        
        public override void AssignBaseSalary() => 
            salary = GetBaseSalary(seniority);

        public override void ApplySalaryIncrement()
        {
            var newAmount = salary.Amount * GetSalaryIncrementPercentage(seniority) * 0.01f + salary.Amount;
            salary = new Salary(newAmount, salary.SalaryCurrency);
        }
    }
}