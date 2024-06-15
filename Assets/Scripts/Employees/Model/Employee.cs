using static Employees.Model.Seniority;

namespace Employees.Model
{
    public abstract class Employee
    {
        protected Seniority seniority;
        
        protected Employee(Seniority seniority)
        {
            this.seniority = seniority;
        }

        public Seniority GetSeniority() => 
            seniority;

        public void RaiseSeniority() => 
            seniority = seniority == Junior ? Semi_Senior : Senior;
    }
}
