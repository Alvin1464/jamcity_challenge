using Employees.Model;
using NUnit.Framework;
using static Employees.Model.Seniority;
using static Employees.Model.Currency;

namespace Tests.Employees.Model
{
    [TestFixture]
    public class DesignerTests
    {
        Designer designer;
        
        [Test]
        public void DesignersAreEmployees() => 
            Assert.IsTrue(typeof(Designer).IsSubclassOf(typeof(Employee)));

        [Test]
        [TestCase(Junior, 800, DOLLARS)]
        [TestCase(Senior, 2000, DOLLARS)]
        public void DesignerBaseSalaryDependsOfTheSeniority(Seniority seniority, int amount, Currency currency)
        {
            GivenADesignerWith(seniority);
            WhenAssignBaseSalary();
            ThenDesignerSalaryIs(new Salary(amount, currency));
        }

        [Test]
        [TestCase(Junior, 4f)]
        [TestCase(Senior, 7f)]
        public void DesignersHaveASalaryIncrementPercentageBasedOfTheSeniority(Seniority seniority, float percentage)
        {
            GivenADesignerWith(seniority, new Salary(1000, DOLLARS));
            var initialSalaryAmount = designer.GetSalary().Amount;
            WhenAppliedSalaryIncrement();
            ThenSalaryAmountIs(initialSalaryAmount * 0.01f * percentage + initialSalaryAmount);
        }

        void GivenADesignerWith(Seniority seniority, Salary salary = new()) => 
            designer = new Designer(seniority, salary);
        
        void WhenAppliedSalaryIncrement() => 
            designer.ApplySalaryIncrement();
        
        void WhenAssignBaseSalary() => 
            designer.AssignBaseSalary();

        void ThenDesignerSalaryIs(Salary salary) => 
            Assert.AreEqual(designer.GetSalary(), salary);

        void ThenSalaryAmountIs(float expectedSalaryAmount) =>
            Assert.AreEqual(designer.GetSalary().Amount, expectedSalaryAmount);
    }
}