using System.Collections.Generic;
using Employees.Model;
using Employees.Model.EmployeeType;
using Employees.Repositories;
using Employees.Services;
using Moq;
using NUnit.Framework;

namespace Tests.Employees.Services
{
    [TestFixture]
    public class GetEmployeesServiceTests
    {
        readonly Mock<EmployeesRepository> repository = new();
        [Test]
        public void GetEmployeesFromRepository()
        {
            var employee = new Ceo();
            var employee2 = new Artist(Seniority.Semi_Senior);
            var employees = new Dictionary<string, Employee>
            {
                {"id_1", employee},
                {"id_2", employee2}
            };
            repository.Setup(m => m.GetEmployees()).Returns(employees);
            var service = new GetEmployeesService(repository.Object);
            var returnedEmployees = service.Execute();
            Assert.AreEqual(returnedEmployees, employees);
        }
    }
}