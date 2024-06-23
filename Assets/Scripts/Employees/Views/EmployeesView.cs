using System;
using System.Collections.Generic;
using System.Linq;
using Employees.Model;
using Employees.Services;
using Employees.Views;
using UnityEngine;
using UnityEngine.UI;
using static Employees.Services.Role;
using static Utils.GetRoleFromEmployee;

public class EmployeesView : MonoBehaviour
{
    [SerializeField] EmployeeItemListView employeeItemPrefab;
    [SerializeField] HirePanelView hirePanelView;
    [SerializeField] Transform container;
    [SerializeField] Button AllFilter;
    [SerializeField] Button HRFilter;
    [SerializeField] Button CEOFilter;
    [SerializeField] Button PMFilter;
    [SerializeField] Button EngineersFilter;
    [SerializeField] Button ArtistsFilter;
    [SerializeField] Button DesignersFilter;
    readonly List<EmployeeItemListView> employeesViews = new();
    public event Action<string> OnApplySalaryIncrementFor;
    public event Action<string, Role, Seniority> OnHire; 

    void Start()
    {
        AllFilter.onClick.AddListener(delegate
        {
            EnableAllButtonFilters();
            AllFilter.interactable = false;
            ShowAllEmployees();
        });
        
        HRFilter.onClick.AddListener(delegate
        {
            EnableAllButtonFilters();
            HRFilter.interactable = false;
            FilterEmployees(HR);
        });
        
        CEOFilter.onClick.AddListener(delegate
        {
            EnableAllButtonFilters();
            CEOFilter.interactable = false;
            FilterEmployees(CEO);
        });
        
        PMFilter.onClick.AddListener(delegate
        {
            EnableAllButtonFilters();
            PMFilter.interactable = false;
            FilterEmployees(PM);
        });
        
        EngineersFilter.onClick.AddListener(delegate
        {
            EnableAllButtonFilters();
            EngineersFilter.interactable = false;
            FilterEmployees(ENGINEER);
        });
        
        ArtistsFilter.onClick.AddListener(delegate
        {
            EnableAllButtonFilters();
            ArtistsFilter.interactable = false;
            FilterEmployees(ARTIST);
        });
        
        DesignersFilter.onClick.AddListener(delegate
        {
            EnableAllButtonFilters();
            DesignersFilter.interactable = false;
            FilterEmployees(DESIGNER);
        });

        hirePanelView.OnHire += OnHireNewEmployee;
    }

    void OnHireNewEmployee(string fullName, Role role, Seniority seniority)
    {
        OnHire?.Invoke(fullName, role, seniority);
    }

    

    void EnableAllButtonFilters()
    {
        AllFilter.interactable = true;
        HRFilter.interactable = true;
        CEOFilter.interactable = true;
        PMFilter.interactable = true;
        EngineersFilter.interactable = true;
        ArtistsFilter.interactable = true;
        DesignersFilter.interactable = true;
    }

    void ShowAllEmployees()
    {
        foreach(var view in employeesViews) 
            view.Show();
    }

    void FilterEmployees(Role role)
    {
        foreach (var view in employeesViews)
            if (view.role == role)
                view.Show();
            else
                view.Hide();
    }

    public void InstantiateAEmployeeItem(string fullName, Role role, Seniority seniority, Salary salary, string id)
    {
        var view = Instantiate(employeeItemPrefab, container, true);
        view.SetEmployee(fullName, role, seniority, salary, id);
        view.OnApplySalaryIncrement += OnApplySalaryIncrement;
        employeesViews.Add(view);
    }

    void OnApplySalaryIncrement(string id) => 
        OnApplySalaryIncrementFor?.Invoke(id);

    public void UpdateFor(Employee employee)
    {
        var employeeView = employeesViews.First(itemView => itemView.id == employee.GetId());
        employeeView.SetEmployee(
            employee.GetFullName(), 
            GetRoleFrom(employee),
            employee.GetSeniority(),
            employee.GetSalary(), 
            employee.GetId());
    }

    public void ClearEmployees()
    {
        foreach (var employeeItemView in employeesViews) {
            employeeItemView.OnApplySalaryIncrement -= OnApplySalaryIncrement;
            Destroy(employeeItemView.gameObject);
        }

        employeesViews.Clear();
    }
}
