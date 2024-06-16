using Employees.Model;
using NUnit.Framework;
using static Employees.Model.Seniority;
using static Employees.Model.Currency;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.Employees.Model
{
    public class HumanResourcesTests
    {
        HumanResources humanResources;
        
        [Test]
        public void HumanResourcesAreEmployees() => 
            Assert.IsTrue(typeof(HumanResources).IsSubclassOf(typeof(Employee)));

        [Test]
        [TestCase(Junior, 500, DOLLARS)]
        [TestCase(Semi_Senior, 1000, DOLLARS)]
        [TestCase(Senior, 1500, DOLLARS)]
        public void HumanResourcesBaseSalaryDependsOfTheSeniority(Seniority seniority, int amount, Currency currency)
        {
            GivenAHumanResourcesWithSeniority(seniority);
            ThenSalaryIs(new Salary(amount, currency));
        }

        [Test]
        [TestCase(Junior, .5f)]
        [TestCase(Semi_Senior, 2f)]
        [TestCase(Senior, 5f)]
        public void HumanResourcesHaveASalaryIncrementPercentageBasedOfTheSeniority(Seniority seniority, float percentage)
        {
            GivenAHumanResourcesWithSeniority(seniority);
            var initialSalaryAmount = humanResources.GetSalary().Amount;
            WhenAppliedSalaryIncrement();
            ThenSalaryAmountIs(initialSalaryAmount * 0.01f * percentage + initialSalaryAmount);
        }

        void GivenAHumanResourcesWithSeniority(Seniority seniority) => 
            humanResources = new HumanResources(seniority);
        
        void WhenAppliedSalaryIncrement() => 
            humanResources.ApplySalaryIncrement();

        void ThenSalaryIs(Salary salary) => 
            Assert.AreEqual(humanResources.GetSalary(), salary);

        void ThenSalaryAmountIs(float expectedSalaryAmount) =>
            Assert.AreEqual(humanResources.GetSalary().Amount, expectedSalaryAmount);
    }
}