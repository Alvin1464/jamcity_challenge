using System;
using Employees.Model;
using Employees.Model.EmployeeType;
using Employees.Repositories;
using Moq;
using static Employees.Model.Seniority;

namespace Employees.Services
{
    public class HireEmployeeService
    {
        readonly IdGenerator idGenerator;
        readonly EmployeesRepository employeesRepository;

        public HireEmployeeService(IdGenerator idGenerator, EmployeesRepository employeesRepository)
        {
            this.idGenerator = idGenerator;
            this.employeesRepository = employeesRepository;
        }

        public Employee Execute(string fullName, Role role, Seniority seniority)
        {
            var employee = GenerateEmployeeBasedOn(role, seniority);
            employee.SetFullName(fullName);
            employee.SetId(idGenerator.GenerateId());
            employeesRepository.SaveEmployee(employee);
            return employee;
        }

        Employee GenerateEmployeeBasedOn(Role role, Seniority seniority) =>
            role switch
            {
                Role.CEO => new Ceo(),
                Role.ARTIST => new Artist(seniority),
                Role.ENGINEER => new Engineer(seniority),
                Role.PM => new ProjectManager(seniority),
                Role.HR => new HumanResources(seniority),
                Role.DESIGNER => new Designer(seniority),
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, "Undefined role")
            };
    }
}