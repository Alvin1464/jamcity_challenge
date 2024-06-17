using Employees.Model;

namespace Employees.Configurations
{
    public static class ProjectManagerConfiguration
    {
        static readonly Salary semiSeniorBaseSalary = new(2400, Currency.DOLLARS);
        static readonly Salary seniorBaseSalary = new(4000, Currency.DOLLARS);
        static readonly float semiSeniorSalaryIncrementPercentage = 5f;
        static readonly float seniorSalaryIncrementPercentage = 10f;
        
        public static float GetSalaryIncrementPercentage(Seniority seniority) =>
            seniority switch
            {
                Seniority.Semi_Senior => semiSeniorSalaryIncrementPercentage,
                Seniority.Senior => seniorSalaryIncrementPercentage,
                _ => 0f
            };
        
        public static Salary GetBaseSalary(Seniority seniority) =>
            seniority switch
            {
                Seniority.Semi_Senior => semiSeniorBaseSalary,
                Seniority.Senior => seniorBaseSalary,
                _ => new Salary()
            };
    }
}