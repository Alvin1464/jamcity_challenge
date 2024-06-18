using static Employees.Model.Seniority;

namespace Employees.Model
{
    public abstract class Employee
    {
        protected Seniority seniority;
        protected Salary salary;
        protected string fullName;
        
        protected Employee(
            Seniority seniority = Junior, 
            Salary salary = new(), 
            string fullName = "no name")
        {
            this.seniority = seniority;
            this.salary = salary;
            this.fullName = fullName;
        }

        public Seniority GetSeniority() => 
            seniority;

        public Salary GetSalary() =>
            salary;

        public void RaiseSeniority() => 
            seniority = seniority == Junior ? Semi_Senior : Senior;

        public string GetFullName() => 
            fullName;
    }
}
