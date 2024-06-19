using System;
using Employees.Model;
using Employees.Model.EmployeeType;
using Employees.Repositories;
using Employees.Services;
using Moq;
using NUnit.Framework;
using static Employees.Model.Seniority;
using static Employees.Services.Role;

namespace Tests.Employees.Services
{
    [TestFixture]
    public class HireEmployeeServiceTest
    {
        HireEmployeeService service;
        Employee hiredEmployee;
        Mock<IdGenerator> idGenerator;
        Mock<EmployeesRepository> repository;
        
        [Test]
        public void HireEmployeeReturnsTheEmployee()
        {
            GivenAHireEmployeeService();
            WhenHireEmployee("full name");
            Assert.AreEqual(hiredEmployee.GetFullName(), "full name");
        }

        [Test]
        [TestCase(CEO, typeof(Ceo))]
        [TestCase(ARTIST, typeof(Artist))]
        [TestCase(ENGINEER, typeof(Engineer))]
        [TestCase(PM, typeof(ProjectManager))]
        [TestCase(HR, typeof(HumanResources))]
        [TestCase(DESIGNER, typeof(Designer))]
        public void HireEmployeesBasedOnTheRole(Role role, Type roleType)
        {
            GivenAHireEmployeeService();
            WhenHireEmployee(role: role);
            ThenEmployeeRoleIs(roleType);
        }

        [Test]
        [TestCase(PM, Junior)]
        [TestCase(ENGINEER, Senior)]
        [TestCase(DESIGNER, Semi_Senior)]
        public void HireEmployeeAssignsASeniority(Role role, Seniority seniority)
        {
            GivenAHireEmployeeService();
            WhenHireEmployee(role:role, seniority: seniority);
            ThenSeniorityIs(seniority);
        }

        [Test]
        [TestCase(CEO, Junior)]
        [TestCase(CEO, Semi_Senior)]
        [TestCase(CEO, Senior)]
        public void WhenHiringACeoAssignAsSeniorAlways(Role role, Seniority seniority)
        {
            GivenAHireEmployeeService();
            WhenHireEmployee(role:role, seniority: seniority);
            ThenSeniorityIs(Senior);
        }

        [Test]
        public void WhenHiringAssignAnIdFromExternalService()
        {
            var id = "generated_id";
            GivenAHireEmployeeService();
            idGenerator.Setup(m => m.GenerateId()).Returns(id);
            WhenHireEmployee();
            ThenEmployeeIdIs(id);
        }

        [Test]
        public void WhenHiringSaveHireInRepository()
        {
            GivenAHireEmployeeService();
            WhenHireEmployee();
            repository.Verify(repo => repo.SaveEmployee(hiredEmployee));
        }

        void GivenAHireEmployeeService()
        {
            idGenerator = new Mock<IdGenerator>();
            repository = new Mock<EmployeesRepository>();
            service = new HireEmployeeService(idGenerator.Object, repository.Object);
        }

        void WhenHireEmployee(string fullName = "", Role role = CEO, Seniority seniority = Junior) => 
            hiredEmployee = service.Execute(fullName, role, seniority);
        
        void ThenEmployeeRoleIs(Type employeeType) => Assert.AreEqual(hiredEmployee.GetType(), 
            employeeType);

        void ThenSeniorityIs(Seniority seniority) => 
            Assert.AreEqual(hiredEmployee.GetSeniority(), seniority);

        void ThenEmployeeIdIs(string id) =>
            Assert.AreEqual(hiredEmployee.GetId(), id);
    }
}