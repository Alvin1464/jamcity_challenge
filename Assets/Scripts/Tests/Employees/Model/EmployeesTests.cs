using Employees.Model;
using Moq;
using NUnit.Framework;

namespace Tests.Employees.Model
{
    [TestFixture]
    public class EmployeesTests
    {
        Employee employee;

        [Test]
        public void EmployeesHaveASeniority()
        {
            GivenAnEmployeeWithSeniority(Seniority.Junior);
            ThenSeniorityIs(Seniority.Junior);
        }

        [Test]
        public void EmployeesSeniorityCanBeRaised()
        {
            GivenAnEmployeeWithSeniority(Seniority.Junior);
            WhenSeniorityIsRaised();
            ThenSeniorityIs(Seniority.Semi_Senior);
            WhenSeniorityIsRaised();
            ThenSeniorityIs(Seniority.Senior);
        }

        [Test]
        public void EmployeesSeniorityCannotBeRaisedAboveSeniorLevel()
        {
            GivenAnEmployeeWithSeniority(Seniority.Senior);
            WhenSeniorityIsRaised();
            ThenSeniorityIs(Seniority.Senior);
        }

        void GivenAnEmployeeWithSeniority(Seniority seniority)
        {
            var mockEmployee = new Mock<Employee>(seniority);
            employee = mockEmployee.Object;
        }
        
        void WhenSeniorityIsRaised() => employee.RaiseSeniority();
        
        void ThenSeniorityIs(Seniority seniority) => 
            Assert.AreEqual(employee.GetSeniority(), seniority);
    }
}