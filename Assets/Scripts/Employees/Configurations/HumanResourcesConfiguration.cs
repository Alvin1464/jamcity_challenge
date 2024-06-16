using Employees.Model;

namespace Employees.Configurations
{
    public static class HumanResourcesConfiguration
    {
        static readonly Salary juniorBaseSalary = new(500, Currency.DOLLARS);
        static readonly Salary semiSeniorBaseSalary = new(1000, Currency.DOLLARS);
        static readonly Salary seniorBaseSalary = new(1500, Currency.DOLLARS);
        static readonly float juniorSalaryIncrementPercentage = .5f;
        static readonly float semiSeniorSalaryIncrementPercentage = 2f;
        static readonly float seniorSalaryIncrementPercentage = 5f;
        
        public static float GetSalaryIncrementPercentage(Seniority seniority) =>
            seniority switch
            {
                Seniority.Junior => juniorSalaryIncrementPercentage,
                Seniority.Semi_Senior => semiSeniorSalaryIncrementPercentage,
                Seniority.Senior => seniorSalaryIncrementPercentage,
                _ => 0f
            };
        
        public static Salary GetBaseSalary(Seniority seniority) =>
            seniority switch
            {
                Seniority.Junior => juniorBaseSalary,
                Seniority.Semi_Senior => semiSeniorBaseSalary,
                Seniority.Senior => seniorBaseSalary,
                _ => new Salary()
            };
    }
}