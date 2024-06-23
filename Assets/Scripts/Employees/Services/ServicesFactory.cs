using Employees.Repositories;
using Employees.Repositories.Impl;
using Employees.Services;
using Employees.Services.Implementation;

public static class ServicesFactory
{
    static GetEmployeesService getEmployeesService;
    static ApplySalaryIncrementService applySalaryIncrementService;
    static HireEmployeeService hireEmployeeService;
    static EmployeesRepository employeesRepository;
    
    public static GetEmployeesService GetEmployeesService()
    {
        if (getEmployeesService != null)
            return getEmployeesService;
        getEmployeesService = new GetEmployeesService(GetEmployeesRepository());
        return getEmployeesService;
    }

    public static HireEmployeeService HireEmployeeService()
    {
        if (hireEmployeeService != null)
            return hireEmployeeService;
        hireEmployeeService = new HireEmployeeService(new IdGeneratorGUID(), GetEmployeesRepository());
        return hireEmployeeService;
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