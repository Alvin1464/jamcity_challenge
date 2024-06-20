using System;
using Employees.Model;
using Employees.Model.EmployeeType;
using Employees.Services;
using static Employees.Services.Role;

namespace Utils
{
    public static class GetRoleFromEmployee
    {
        public static Role GetRoleFrom(Employee employee)
        {
            return employee switch
            {
                Ceo => CEO,
                Artist => ARTIST,
                Engineer => ENGINEER,
                Designer => DESIGNER,
                ProjectManager => PM,
                HumanResources => HR,
                _ => throw new Exception("employee role is not defined")
            };
        }
    }
}