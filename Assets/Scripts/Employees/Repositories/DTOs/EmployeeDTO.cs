using System;
using Employees.Model;
using Employees.Model.EmployeeType;
using Employees.Services;
using JetBrains.Annotations;
using static Employees.Services.Role;
using static Utils.GetRoleFromEmployee;

namespace Employees.Repositories.DTOs
{
    public struct EmployeeDTO
    {
        public string id;
        public string fullName;
        public string role;
        public string seniority;
        public float salaryAmount;
        public string salaryCurrency;

        public EmployeeDTO(Employee employee)
        {
            seniority = employee.GetSeniority().ToString();
            salaryAmount = employee.GetSalary().Amount;
            salaryCurrency = employee.GetSalary().SalaryCurrency.ToString();
            fullName = employee.GetFullName();
            id = employee.GetId();
            role = GetRoleFrom(employee).ToString();
        }

        public Employee ToEmployee()
        {
            //TODO: checkear si el DTO puede tener structs y Enums asi lo parseo mucho mas facil y seguro.
            var employee = GenerateEmployeeBasedOn(Enum.Parse<Role>(role), Enum.Parse<Seniority>(seniority));
            employee.SetId(id);
            employee.SetFullName(fullName);
            employee.SetSalary(new Salary(salaryAmount, Enum.Parse<Currency>(salaryCurrency)));
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