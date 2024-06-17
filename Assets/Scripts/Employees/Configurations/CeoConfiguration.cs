using Employees.Model;

namespace Employees.Configurations
{
    public class CeoConfiguration
    {
        static readonly Salary seniorBaseSalary = new(20000, Currency.DOLLARS);
        static readonly float seniorSalaryIncrementPercentage = 100f;
        
        public static float GetSalaryIncrementPercentage(Seniority seniority) =>
            seniority switch
            {
                Seniority.Senior => seniorSalaryIncrementPercentage,
                _ => 0f
            };
        
        public static Salary GetBaseSalary(Seniority seniority) =>
            seniority switch
            {
                Seniority.Senior => seniorBaseSalary,
                _ => new Salary()
            };
    }
}