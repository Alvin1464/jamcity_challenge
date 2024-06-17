using Employees.Model;
using Employees.Model.EmployeeType;
using NUnit.Framework;
using static Employees.Model.Currency;
using static Employees.Model.Seniority;

namespace Tests.Employees.Model
{
    [TestFixture]
    public class CeoTests
    {
        Ceo ceo;
        
        [Test]
        public void CeoIsAEmployee() => 
            Assert.IsTrue(typeof(Ceo).IsSubclassOf(typeof(Employee)));

        [Test]
        public void CeoSeniorityIsSenior()
        {
            GivenACeo();
            ThenSeniorityIs(Senior);
        }

        [Test]
        [TestCase(20000, DOLLARS)]
        public void CeoBaseSalaryIs(float amount, Currency currency)
        {
            GivenACeo();
            WhenAssignBaseSalary();
            ThenSalaryIs(new Salary(amount, currency));
        }

        [Test]
        [TestCase(100f)]
        public void CeoHaveASalaryIncrementPercentageOf(float percentage)
        {
            GivenACeo(new Salary(300000f, DOLLARS));
            var initialSalaryAmount = ceo.GetSalary().Amount;
            WhenAppliedSalaryIncrement();
            ThenSalaryAmountIs(initialSalaryAmount*2);
        }

        void GivenACeo(Salary salary = new ()) => 
            ceo = new Ceo(salary);

        void WhenAppliedSalaryIncrement() => 
            ceo.ApplySalaryIncrement();

        void WhenAssignBaseSalary() => 
            ceo.AssignBaseSalary();

        void ThenSeniorityIs(Seniority seniority) => 
            UnityEngine.Assertions.Assert.AreEqual(ceo.GetSeniority(), seniority);
        
        void ThenSalaryIs(Salary salary) =>
            Assert.AreEqual(ceo.GetSalary(), salary);
        
        void ThenSalaryAmountIs(float expectedAmount) => 
            UnityEngine.Assertions.Assert.AreEqual(ceo.GetSalary().Amount, expectedAmount);
    }
}