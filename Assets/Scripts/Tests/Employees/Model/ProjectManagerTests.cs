using Employees.Model;
using Employees.Model.EmployeeType;
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
        public void ProjectManagersAreEmployees() => 
            Assert.IsTrue(typeof(ProjectManager).IsSubclassOf(typeof(Employee)));

        [Test]
        [TestCase(Semi_Senior, 2400, DOLLARS)]
        [TestCase(Senior, 4000, DOLLARS)]
        public void ProjectManagerBaseSalaryDependsOfTheSeniority(Seniority seniority, int amount, Currency currency)
        {
            GivenAProjectManager(seniority);
            WhenAssignBaseSalary();
            ThenSalaryIs(new Salary(amount, currency));
        }

        [Test]
        [TestCase(Semi_Senior, 5f)]
        [TestCase(Senior, 10f)]
        public void ProjectManagerHaveASalaryIncrementPercentageBasedOfTheSeniority(
            Seniority seniority, float percentage)
        {
            GivenAProjectManager(seniority, new Salary(1000, DOLLARS));
            var initialSalaryAmount = projectManager.GetSalary().Amount;
            WhenAppliedSalaryIncrement();
            ThenSalaryAmountIs(initialSalaryAmount * 0.01f * percentage + initialSalaryAmount);
        }

        void GivenAProjectManager(Seniority seniority = Junior, Salary salary = new()) => 
            projectManager = new ProjectManager(seniority, salary);
        
        
        void WhenAppliedSalaryIncrement() => 
            projectManager.ApplySalaryIncrement();
        
        void WhenAssignBaseSalary() => 
            projectManager.AssignBaseSalary();

        void ThenSalaryIs(Salary salary) => 
            Assert.AreEqual(projectManager.GetSalary(), salary);

        void ThenSalaryAmountIs(float expectedSalaryAmount) =>
            Assert.AreEqual(projectManager.GetSalary().Amount, expectedSalaryAmount);
    }
}