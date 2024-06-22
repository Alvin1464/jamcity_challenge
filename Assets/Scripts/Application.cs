using System.Collections.Generic;
using System.Linq;
using Employees.Model;
using UnityEngine;
using static ServicesFactory;
using GetEmployeesService = Employees.Services.GetEmployeesService;

public class Application : MonoBehaviour
{
    [SerializeField]
    EmployeesView employeesView;

    EmployeesPresenter employeesPresenter;

    void Awake()
    {
        employeesPresenter = new EmployeesPresenter(employeesView, GetEmployeesService());
        employeesPresenter.PopulateEmployees();
    }

    void Update()
    {
        
    }
}