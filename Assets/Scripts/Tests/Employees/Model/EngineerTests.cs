using Employees.Model;
using Employees.Model.EmployeeType;
using NUnit.Framework;
using static Employees.Model.Currency;
using static Employees.Model.Seniority;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.Employees.Model
{
    [TestFixture]
    public class EngineerTests
    {
        Engineer engineer;
        
        [Test]
        public void EngineersAreEmployees() => 
            Assert.IsTrue(typeof(Engineer).IsSubclassOf(typeof(Employee)));

        [Test]
        [TestCase(Junior, 1500, DOLLARS)]
        [TestCase(Semi_Senior, 3000, DOLLARS)]
        [TestCase(Senior, 5000, DOLLARS)]
        public void EngineerBaseSalaryDependsOfTheSeniority(Seniority seniority, int amount, Currency currency)
        {
            GivenAEngineerWith(seniority);
            WhenAssignBaseSalary();
            ThenEngineerSalaryIs(new Salary(amount, currency));
        }

        [Test]
        [TestCase(Junior, 5f)]
        [TestCase(Semi_Senior, 7f)]
        [TestCase(Senior, 10f)]
        public void EngineersHaveASalaryIncrementPercentageBasedOfTheSeniority(Seniority seniority, float percentage)
        {
            GivenAEngineerWith(seniority, new Salary(1000, DOLLARS));
            var initialSalaryAmount = engineer.GetSalary().Amount;
            WhenAppliedSalaryIncrement();
            ThenSalaryAmountIs(initialSalaryAmount * 0.01f * percentage + initialSalaryAmount);
        }

        void GivenAEngineerWith(Seniority seniority, Salary salary = new()) => 
            engineer = new Engineer(seniority, salary);
        
        void WhenAppliedSalaryIncrement() => 
            engineer.ApplySalaryIncrement();
        
        void WhenAssignBaseSalary() => 
            engineer.AssignBaseSalary();

        void ThenEngineerSalaryIs(Salary salary) => 
            Assert.AreEqual(engineer.GetSalary(), salary);

        void ThenSalaryAmountIs(float expectedSalaryAmount) =>
            Assert.AreEqual(engineer.GetSalary().Amount, expectedSalaryAmount);
    }
}