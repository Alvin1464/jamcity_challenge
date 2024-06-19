using Employees.Model;

namespace Employees.Repositories
{
    public interface EmployeesRepository
    {
        public void SaveEmployee(Employee employee);
    }
}