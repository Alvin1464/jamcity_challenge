using static Employees.Model.Seniority;

namespace Employees.Model
{
    public abstract class Employee
    {
        protected Seniority seniority = Junior;
        
        public Seniority GetSeniority() => 
            seniority;

        public void RaiseSeniority() => 
            seniority = seniority == Junior ? Semi_Senior : Senior;
    }
}
