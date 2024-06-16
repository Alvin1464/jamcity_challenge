using Employees.Model;

namespace Employees.Configurations
{
    public class DesignerConfiguration
    {
        static readonly Salary juniorBaseSalary = new(800, Currency.DOLLARS);
        static readonly Salary seniorBaseSalary = new(2000, Currency.DOLLARS);
        static readonly float juniorIncrementPercentage = 4f;
        static readonly float seniorSalaryIncrementPercentage = 7f;
        
        public static float GetSalaryIncrementPercentage(Seniority seniority) =>
            seniority switch
            {
                Seniority.Junior => juniorIncrementPercentage,
                Seniority.Senior => seniorSalaryIncrementPercentage,
                _ => 0f
            };
        
        public static Salary GetBaseSalary(Seniority seniority) =>
            seniority switch
            {
                Seniority.Junior => juniorBaseSalary,
                Seniority.Senior => seniorBaseSalary,
                _ => new Salary()
            };
    }
}