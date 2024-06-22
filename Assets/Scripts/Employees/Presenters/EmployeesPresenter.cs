using System.Linq;
using Employees.Services;
using Utils;

public class EmployeesPresenter
{
    readonly EmployeesView employeesView;
    readonly GetEmployeesService getEmployeesService;

    public EmployeesPresenter(EmployeesView employeesView, GetEmployeesService getEmployeesService)
    {
        this.employeesView = employeesView;
        this.getEmployeesService = getEmployeesService;
    }

    public void PopulateEmployees()
    {
        var employeesDictionary = getEmployeesService.Execute();
        var employees = employeesDictionary.ToList().Select(x => x.Value);
        
        employeesView.OnApplySalaryIncrementFor -= OnIncrementSalaryAmountFor;
        foreach (var employee in employees)
        {
            employeesView.InstantiateAEmployeeItem(
                employee.GetFullName(),
                GetRoleFromEmployee.GetRoleFrom(employee),
                employee.GetSeniority(), 
                employee.GetSalary(),
                employee.GetId());
        }
        
        employeesView.OnApplySalaryIncrementFor += OnIncrementSalaryAmountFor;
        
    }

    void OnIncrementSalaryAmountFor(string id)
    {
        var employee = ServicesFactory.ApplySalaryIncrementService().Execute(id);
        if (employee != null)
            employeesView.UpdateFor(employee);
    }
}