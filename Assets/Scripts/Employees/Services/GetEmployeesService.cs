using System.Collections.Generic;
using Employees.Model;
using Employees.Repositories;
using Moq;

namespace Employees.Services
{
    public class GetEmployeesService
    {
        readonly EmployeesRepository repository;

        public GetEmployeesService(EmployeesRepository repository) => 
            this.repository = repository;

        public Dictionary<string, Employee> Execute() => 
            repository.GetEmployees();
    }
}