using System;
using Employees.Model;
using Employees.Model.EmployeeType;
using Employees.Services;
using static Employees.Services.Role;
using static Utils.GetRoleFromEmployee;

namespace Employees.Repositories.DTOs
{
    public struct EmployeeDTO
    {
        public string id;
        public string fullName;
        public Role role;
        public Seniority seniority;
        public float salaryAmount;
        public Currency salaryCurrency;

        public EmployeeDTO(Employee employee)
        {
            seniority = employee.GetSeniority();
            salaryCurrency = employee.GetSalary().SalaryCurrency;
            salaryAmount = employee.GetSalary().Amount;
            fullName = employee.GetFullName();
            id = employee.GetId();
            role = GetRoleFrom(employee);
        }

        public Employee ToEmployee()
        {
            var employee = GenerateEmployeeBasedOn(role, seniority);
            employee.SetId(id);
            employee.SetFullName(fullName);
            employee.SetSalary(new Salary(salaryAmount, salaryCurrency));
            return employee;
        }
        
        Employee GenerateEmployeeBasedOn(Role role, Seniority seniority) =>
            role switch
            {
                CEO => new Ceo(),
                ARTIST => new Artist(seniority),
                ENGINEER => new Engineer(seniority),
                PM => new ProjectManager(seniority),
                HR => new HumanResources(seniority),
                DESIGNER => new Designer(seniority),
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, "Undefined role")
            };
    }
}