using static Employees.Model.Seniority;

namespace Employees.Model
{
    public abstract class Employee
    {
        protected Seniority seniority;
        protected Salary salary;
        protected string fullName;
        protected string id;
        
        protected Employee(
            Seniority seniority = Junior, 
            Salary salary = new(), 
            string fullName = "no name",
            string id = "no id")
        {
            this.seniority = seniority;
            this.salary = salary;
            this.fullName = fullName;
            this.id = id;
        }

        public Seniority GetSeniority() => 
            seniority;

        public Salary GetSalary() =>
            salary;

        public void SetFullName(string value)
        {
            fullName = value;
        }

        public void RaiseSeniority() => 
            seniority = seniority == Junior ? Semi_Senior : Senior;

        public string GetFullName() => 
            fullName;

        public string GetId() => id;

        public void SetId(string value) => id = value;
    }
}
