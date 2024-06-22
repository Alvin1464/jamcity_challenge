using System.Collections.Generic;
using Employees.Model;
using Employees.Model.EmployeeType;
using Employees.Repositories;
using Employees.Services;
using Moq;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Employees.Services
{
    [TestFixture]
    public class ApplySalaryIncrementServiceTests
    {
        ApplySalaryIncrementService service;
        Mock<EmployeesRepository> repositoryMock;
        Employee result;
        
        [Test]
        public void ApplySalaryIncrementServiceFetchEmployeesRepository()
        {
            GivenASalaryIncrementService();
            repositoryMock.Setup(repo => repo.GetEmployees())
                .Returns(new Dictionary<string, Employee>());
            WhenExecute("id");
            ThenGetFromRepositoryWasCalled();
        }

        [Test]
        public void IfEmployeeWithIdDontExistInRepositoryReturnsNull()
        {
            GivenASalaryIncrementService();
            repositoryMock.Setup(repo => repo.GetEmployees())
                .Returns(new Dictionary<string, Employee>());
            WhenExecute("id");
            ThenServiceReturnsNull();
        }
        
        [Test]
        public void IfEmployeeWithIdExistsInRepositoryThenApplySalaryIncrement()
        {
            var employee = new Ceo(new Salary(1000, Currency.DOLLARS));
            var startingSalaryAmount = employee.GetSalary().Amount;
            GivenASalaryIncrementService();
            repositoryMock.Setup(repo => repo.GetEmployees())
                .Returns(new Dictionary<string, Employee>{{"id", employee}});
            WhenExecute("id");
            ThenApplySalaryIncrementFor(employee.GetId(), startingSalaryAmount);
        }
        
        [Test]
        public void AfterApplySalaryIncrementSaveEmployeeInRepository()
        {
            var employee = new Ceo(new Salary(1000));
            GivenASalaryIncrementService();
            repositoryMock.Setup(repo => repo.GetEmployees())
                .Returns(new Dictionary<string, Employee>{{"id", employee}});
            WhenExecute("id");
            ThenSaveInRepository(employee);
        }

        void GivenASalaryIncrementService()
        {
            repositoryMock = new Mock<EmployeesRepository>();
            service = new ApplySalaryIncrementService(repositoryMock.Object);
        }
        
        void WhenExecute(string employeeId) => 
            result = service.Execute(employeeId);
        
        void ThenGetFromRepositoryWasCalled() => 
            repositoryMock.Verify(repo => repo.GetEmployees());
        
        void ThenServiceReturnsNull() => Assert.IsTrue(result is null);
        
        void ThenApplySalaryIncrementFor(string id, float startingSalaryAmount)
        {
            Assert.AreEqual(id, result.GetId());
            Assert.IsTrue(startingSalaryAmount < result.GetSalary().Amount);
        }
        
        void ThenSaveInRepository(Employee employee) => 
            repositoryMock.Verify(repo => repo.SaveEmployee(employee));
    }
}
