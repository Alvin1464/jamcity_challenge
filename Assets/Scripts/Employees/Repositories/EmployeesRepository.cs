using System.Collections.Generic;
using Employees.Model;

namespace Employees.Repositories
{
    public interface EmployeesRepository
    {
        public void SaveEmployee(Employee employee);
        Dictionary<string, Employee> GetEmployees();
    }
}