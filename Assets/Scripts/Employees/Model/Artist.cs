using static Employees.Configurations.ArtistConfiguration;

namespace Employees.Model
{
    public class Artist : Employee
    {
        public Artist(Seniority seniority, Salary salary = new()) : base(seniority, salary)
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