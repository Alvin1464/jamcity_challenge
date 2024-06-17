using Employees.Model;
using NUnit.Framework;
using static Employees.Model.Currency;
using static Employees.Model.Seniority;

namespace Tests.Employees.Model
{
    [TestFixture]
    public class ProjectManagerTests
    {
        ProjectManager projectManager;
        
        [Test]
        public void HumanResourcesAreEmployees() => 
            Assert.IsTrue(typeof(ProjectManager).IsSubclassOf(typeof(Employee)));

        [Test]
        [TestCase(Semi_Senior, 2400, DOLLARS)]
        [TestCase(Senior, 4000, DOLLARS)]
        public void ProjectManagerBaseSalaryDependsOfTheSeniority(Seniority seniority, int amount, Currency currency)
        {
            GivenAProjectManagerWithSeniority(seniority);
            ThenSalaryIs(new Salary(amount, currency));
        }

        [Test]
        [TestCase(Semi_Senior, 5f)]
        [TestCase(Senior, 10f)]
        public void ProjectManagerHaveASalaryIncrementPercentageBasedOfTheSeniority(Seniority seniority, float percentage)
        {
            GivenAProjectManagerWithSeniority(seniority);
            var initialSalaryAmount = projectManager.GetSalary().Amount;
            WhenAppliedSalaryIncrement();
            ThenSalaryAmountIs(initialSalaryAmount * 0.01f * percentage + initialSalaryAmount);
        }

        void GivenAProjectManagerWithSeniority(Seniority seniority) => 
            projectManager = new ProjectManager(seniority);
        
        void WhenAppliedSalaryIncrement() => 
            projectManager.ApplySalaryIncrement();

        void ThenSalaryIs(Salary salary) => 
            Assert.AreEqual(projectManager.GetSalary(), salary);

        void ThenSalaryAmountIs(float expectedSalaryAmount) =>
            Assert.AreEqual(projectManager.GetSalary().Amount, expectedSalaryAmount);
    }
}