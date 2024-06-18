using Employees.Model;
using Employees.Services;
using NUnit.Framework;

namespace Tests.Employees.Services
{
    [TestFixture]
    public class HireEmployeeServiceTest
    {
        HireEmployeeService service;
        
        //[Test]
        public void hireEmployeeReturnsTheEmployee()
        {
            var employee = service.Execute("full name");
            Assert.AreEqual(employee.GetFullName(), "full name");
        }
    }
}