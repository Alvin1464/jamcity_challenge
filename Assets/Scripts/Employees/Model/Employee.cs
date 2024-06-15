using static Employees.Model.Currency;
using static Employees.Model.Seniority;

namespace Employees.Model
{
    public abstract class Employee
    {
        protected Seniority seniority;
        protected Salary salary;
        
        protected Employee(Seniority seniority = Junior, Salary salary = new())
        {
            this.seniority = seniority;
            this.salary = salary;
        }

        public Seniority GetSeniority() => 
            seniority;

        public Salary GetSalary() =>
            salary;

        public void RaiseSeniority() => 
            seniority = seniority == Junior ? Semi_Senior : Senior;
    }
}
