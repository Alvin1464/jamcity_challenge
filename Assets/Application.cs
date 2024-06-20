using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Employees.Model;
using Employees.Repositories.Impl;
using Employees.Services;
using UnityEngine;
using static ServicesFactory;
using static Utils.GetRoleFromEmployee;

public class Application : MonoBehaviour
{
    [SerializeField]
    EmployeesView employeesView;

    Dictionary<string, Employee> employeesDictionary;
    EmployeesPresenter employeesPresenter;

    // Start is called before the first frame update
    void Start()
    {
        FetchEmployees();
        employeesPresenter = new EmployeesPresenter(employeesView);
        employeesPresenter.PopulateEmployees(
            employeesDictionary.Select(x => x.Value).ToList()
        );

    }

    void FetchEmployees() => 
        employeesDictionary = GetEmployeesService().Execute();

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class EmployeesPresenter
{
    readonly EmployeesView employeesView;

    public EmployeesPresenter(EmployeesView employeesView)
    {
        this.employeesView = employeesView;
    }

    public void PopulateEmployees(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            employeesView.InstantiateAEmployeeItem(
                employee.GetFullName(),
                GetRoleFrom(employee),
                employee.GetSeniority(), 
                employee.GetSalary(),
                employee.GetId());
        }
        
    }
}

public static class ServicesFactory
{
    static GetEmployeesService createdService;
    
    public static GetEmployeesService GetEmployeesService()
    {
        if (createdService != null)
            return createdService;
        createdService = new GetEmployeesService(new EmployeesRepositoryJson());
        return createdService;

    }
}
