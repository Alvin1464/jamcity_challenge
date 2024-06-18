using Employees.Model;
using Employees.Model.EmployeeType;

namespace Employees.Services
{
    public class HireEmployeeService
    {
        public Employee Execute(string fullName)
        {
            var ceo = new Ceo();
            ceo.SetFullName(fullName);
            return new Ceo();
        }
    }
}