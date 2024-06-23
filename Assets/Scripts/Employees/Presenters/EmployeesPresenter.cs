using System.Collections.Generic;
using System.Linq;
using Employees.Model;
using Employees.Services;
using static ServicesFactory;
using static Utils.GetRoleFromEmployee;

public class EmployeesPresenter
{
    readonly EmployeesView employeesView;
    readonly GetEmployeesService getEmployeesService;

    public EmployeesPresenter(EmployeesView employeesView, GetEmployeesService getEmployeesService)
    {
        this.employeesView = employeesView;
        this.getEmployeesService = getEmployeesService;
        employeesView.OnHire += OnHire;
    }

    public void PopulateEmployees()
    {
        var employeesDictionary = getEmployeesService.Execute();
        var employees = GetOrderedEmployeesInList(employeesDictionary);
        
        employeesView.ClearEmployees();
        employeesView.OnApplySalaryIncrementFor -= OnIncrementSalaryAmountFor;
        
        foreach (var employee in employees)
        {
            employeesView.InstantiateAEmployeeItem(
                employee.GetFullName(),
                GetRoleFrom(employee),
                employee.GetSeniority(), 
                employee.GetSalary(),
                employee.GetId());
        }
        
        employeesView.OnApplySalaryIncrementFor += OnIncrementSalaryAmountFor;
    }
    
    void OnIncrementSalaryAmountFor(string id)
    {
        var employee = ApplySalaryIncrementService().Execute(id);
        if (employee != null)
            employeesView.UpdateFor(employee);
    }

    static IOrderedEnumerable<Employee> GetOrderedEmployeesInList(Dictionary<string, Employee> employeesDictionary) =>
        employeesDictionary.ToList()
            .Select(x => x.Value)
            .OrderByDescending(x => x.GetSeniority())
            .ThenByDescending(GetRoleFrom);

    void OnHire(string fullName, Role role, Seniority seniority)
    {
        HireEmployeeService().Execute(fullName, role, seniority);
        PopulateEmployees();
    }
}