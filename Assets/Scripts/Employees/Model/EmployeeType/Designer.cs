using static Employees.Configurations.DesignerConfiguration;

namespace Employees.Model.EmployeeType
{
    public class Designer : Employee
    {
        public Designer(Seniority seniority, Salary salary = new()) : base(seniority, salary)
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