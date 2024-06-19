using System;
using Employees.Model;
using Employees.Model.EmployeeType;
using Employees.Services;
using JetBrains.Annotations;
using static Employees.Services.Role;

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
            role = GetRole(employee).ToString();
        }

        static Role GetRole([CanBeNull] Employee employee)
        {
            return employee switch
            {
                Ceo => CEO,
                Artist => ARTIST,
                Engineer => ENGINEER,
                ProjectManager => PM,
                HumanResources => HR,
                Designer => DESIGNER,
                _ => throw new Exception("Role not exist")
            };
        }
    }
}