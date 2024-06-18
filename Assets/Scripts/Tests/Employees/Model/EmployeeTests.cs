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
            GivenAEmployeeWith(seniority:Junior);
            ThenSeniorityIs(Junior);
        }

        [Test]
        public void EmployeesSeniorityCanBeRaised()
        {
            GivenAEmployeeWith(seniority:Junior);
            WhenSeniorityIsRaised();
            ThenSeniorityIs(Semi_Senior);
            WhenSeniorityIsRaised();
            ThenSeniorityIs(Senior);
        }

        [Test]
        public void EmployeesSeniorityCannotBeRaisedAboveSeniorLevel()
        {
            GivenAEmployeeWith(seniority:Senior);
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
            GivenAEmployeeWith();
            WhenSetFullName(fullName);
            ThenFullNameIs(fullName);
        }

        void WhenSetFullName(string fullName) => employee.SetFullName(fullName);

        [Test]
        public void EmployeeHaveAnID()
        {
            var id = "id";
            GivenAEmployeeWith(id: id);
            ThenIdIs(id);
        }

        void GivenAEmployeeWith(
            Salary salary = new(), 
            Seniority seniority = Junior, 
            string fullName = "",
            string id = "")
        {
            var mockEmployee = new Mock<Employee>(seniority, salary, fullName, id);
            employee = mockEmployee.Object;
        }

        void WhenSeniorityIsRaised() => employee.RaiseSeniority();
        
        void ThenFullNameIs(string fullName) => 
            Assert.AreEqual(fullName, employee.GetFullName());
        
        void ThenIdIs(string id) => 
            Assert.AreEqual(id, employee.GetId());

        void ThenSeniorityIs(Seniority seniority) => 
            Assert.AreEqual(employee.GetSeniority(), seniority);

        void ThenSalaryIs(Salary salary) =>
            Assert.AreEqual(employee.GetSalary(), salary);
    }
}