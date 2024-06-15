using Employees.Model;
using Moq;
using NUnit.Framework;

namespace Tests.Employees.Model
{
    [TestFixture]
    public class EmployeesTests
    {

        [Test]
        public void EmployeesHaveASeniority()
        {
            var mockEmployee = new Mock<Employee>();
            var employee = mockEmployee.Object;
            var currentSeniority = employee.GetSeniority();
            Assert.AreEqual(currentSeniority, Seniority.Junior);
        }

        [Test]
        public void EmployeesSeniorityCanBeRaisedUntilSenior()
        {
            var mockEmployee = new Mock<Employee>();
            var employee = mockEmployee.Object;
            Assert.AreEqual(employee.GetSeniority(), Seniority.Junior);
            employee.RaiseSeniority();
            Assert.AreEqual(employee.GetSeniority(), Seniority.Semi_Senior);
            employee.RaiseSeniority();
            Assert.AreEqual(employee.GetSeniority(), Seniority.Senior);
            employee.RaiseSeniority();
            Assert.AreEqual(employee.GetSeniority(), Seniority.Senior);
        }
    }
}