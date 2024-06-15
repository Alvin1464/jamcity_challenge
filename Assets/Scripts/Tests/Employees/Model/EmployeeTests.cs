using Employees.Model;
using Moq;
using NUnit.Framework;
using static Employees.Model.Currency;
using static Employees.Model.Seniority;

namespace Tests.Employees.Model
{
    [TestFixture]
    public class EmployeeTests
    {
        Employee employee;

        [Test]
        public void EmployeesHaveASeniority()
        {
            GivenAnEmployeeWithSeniority(Junior);
            ThenSeniorityIs(Junior);
        }

        [Test]
        public void EmployeesSeniorityCanBeRaised()
        {
            GivenAnEmployeeWithSeniority(Junior);
            WhenSeniorityIsRaised();
            ThenSeniorityIs(Semi_Senior);
            WhenSeniorityIsRaised();
            ThenSeniorityIs(Senior);
        }

        [Test]
        public void EmployeesSeniorityCannotBeRaisedAboveSeniorLevel()
        {
            GivenAnEmployeeWithSeniority(Senior);
            WhenSeniorityIsRaised();
            ThenSeniorityIs(Senior);
        }
        
        [Test]
        public void EmployeeHaveASalary()
        {
            var employeeSalary = new Salary(1000, DOLLARS);
            GivenAEmployeeWithSalary(employeeSalary);
            ThenSalaryIs(employeeSalary);
        }

        void GivenAEmployeeWithSalary(Salary salary)
        {
            var mockEmployee = new Mock<Employee>(Junior, salary);
            employee = mockEmployee.Object;
        }

        void GivenAnEmployeeWithSeniority(Seniority seniority)
        {
            var mockEmployee = new Mock<Employee>(seniority, new Salary());
            employee = mockEmployee.Object;
        }
        
        void WhenSeniorityIsRaised() => employee.RaiseSeniority();
        
        void ThenSeniorityIs(Seniority seniority) => 
            Assert.AreEqual(employee.GetSeniority(), seniority);

        void ThenSalaryIs(Salary salary) =>
            Assert.AreEqual(employee.GetSalary(), salary);
    }
}