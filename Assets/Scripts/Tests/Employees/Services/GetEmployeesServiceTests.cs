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
        GetEmployeesService service;
        readonly Mock<EmployeesRepository> repository = new();
        Dictionary<string, Employee> returnedEmployees;

        [Test]
        public void GetEmployeesFromRepository()
        {
            var employees = 
                GivenARepositoryWithEmployees(out var employee, out var employee2);
            GivenAGetEmployeesService();
            WhenExecuteService(service);
            ThenFetchedEmployeesAre(employees);
        }

        void ThenFetchedEmployeesAre(Dictionary<string, Employee> employees) => 
            Assert.AreEqual(employees, returnedEmployees);

        void WhenExecuteService(GetEmployeesService service) => 
            returnedEmployees = service.Execute();

        void GivenAGetEmployeesService()
        {
            service = new GetEmployeesService(repository.Object);
        }

        Dictionary<string, Employee> GivenARepositoryWithEmployees(out Ceo employee, out Artist employee2)
        {
            employee = new Ceo();
            employee2 = new Artist(Seniority.Semi_Senior);
            var employees = new Dictionary<string, Employee>
            {
                { "id_1", employee },
                { "id_2", employee2 }
            };
            repository.Setup(m => m.GetEmployees()).Returns(employees);
            return employees;
        }
    }
}