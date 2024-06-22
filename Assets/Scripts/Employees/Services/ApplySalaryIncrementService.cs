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
        
        [CanBeNull]
        public Employee Execute(string id)
        {
            var employees = repository.GetEmployees();
            if (!employees.TryGetValue(id, out var employee)) 
                return null;
            employee.ApplySalaryIncrement();
            repository.SaveEmployee(employee);
            return employee;
        } 
    }
}