using Employees.Model;
using Employees.Repositories;
using JetBrains.Annotations;

namespace Employees.Services
{
    public class ApplySalaryIncrementService
    {
        readonly EmployeesRepository repository;

        public ApplySalaryIncrementService(EmployeesRepository repository)
        {
            this.repository = repository;
        }
        //TODO: hacer test
        [CanBeNull]
        public Employee Execute(string id)
        {
            var employees = repository.GetEmployees();
            if (employees.ContainsKey(id))
            {
                var employee = employees[id];
                employee.ApplySalaryIncrement();
                repository.SaveEmployee(employee);
                return employee;
            }

            return null;
        } 
    }
}