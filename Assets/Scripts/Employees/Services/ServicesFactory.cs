using Employees.Repositories;
using Employees.Repositories.Impl;
using Employees.Services;

public static class ServicesFactory
{
    static GetEmployeesService getEmployeesService;
    static ApplySalaryIncrementService applySalaryIncrementService;
    static EmployeesRepository employeesRepository;
    
    public static GetEmployeesService GetEmployeesService()
    {
        if (getEmployeesService != null)
            return getEmployeesService;
        getEmployeesService = new GetEmployeesService(GetEmployeesRepository());
        return getEmployeesService;
    }

    public static ApplySalaryIncrementService ApplySalaryIncrementService()
    {
        if (applySalaryIncrementService != null)
            return applySalaryIncrementService;
        applySalaryIncrementService = new ApplySalaryIncrementService(GetEmployeesRepository());
        return applySalaryIncrementService;
    }

    static EmployeesRepository GetEmployeesRepository()
    {
        if (employeesRepository != null)
            return employeesRepository;
        employeesRepository = new EmployeesRepositoryJson();
        return employeesRepository;
    }
}