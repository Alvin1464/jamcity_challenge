using System;

namespace Employees.Services.Implementation
{
    public class IdGeneratorGUID : IdGenerator
    {
        public string GenerateId() => 
            Guid.NewGuid().ToString();
    }
}