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
            GivenAEmployeeWith(employeeSalary);
            ThenSalaryIs(employeeSalary);
        }

        [Test]
        public void EmployeeHaveAFullName()
        {
            var fullName = "Name Surname";
            GivenAEmployeeWith(fullName: fullName);
            ThenFullNameIs(fullName);
        }

        void GivenAEmployeeWith(Salary salary = new(), Seniority seniority = Junior, string fullName = "")
        {
            var mockEmployee = new Mock<Employee>(seniority, salary, fullName);
            employee = mockEmployee.Object;
        }

        void GivenAnEmployeeWithSeniority(Seniority seniority)
        {
            var mockEmployee = new Mock<Employee>(seniority, new Salary());
            employee = mockEmployee.Object;
        }
        
        void ThenFullNameIs(string fullName) => 
            Assert.AreEqual(fullName, employee.GetFullName());
        
        void WhenSeniorityIsRaised() => employee.RaiseSeniority();
        
        void ThenSeniorityIs(Seniority seniority) => 
            Assert.AreEqual(employee.GetSeniority(), seniority);

        void ThenSalaryIs(Salary salary) =>
            Assert.AreEqual(employee.GetSalary(), salary);
    }
}