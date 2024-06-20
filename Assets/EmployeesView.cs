using System;
using System.Collections.Generic;
using Employees.Model;
using Employees.Services;
using Employees.Views;
using UnityEngine;
using UnityEngine.UI;
using static Employees.Services.Role;

public class EmployeesView : MonoBehaviour
{
    [SerializeField] EmployeeItemListView employeeItemPrefab;
    [SerializeField] Transform container;
    [SerializeField] Button AllFilter;
    [SerializeField] Button HRFilter;
    [SerializeField] Button CEOFilter;
    [SerializeField] Button PMFilter;
    [SerializeField] Button EngineersFilter;
    [SerializeField] Button ArtistsFilter;
    [SerializeField] Button DesignersFilter;
    readonly List<EmployeeItemListView> employeesViews = new();

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
        employeesViews.Add(view);
    }
}
