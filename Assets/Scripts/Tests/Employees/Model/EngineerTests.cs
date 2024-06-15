using Employees.Model;
using NUnit.Framework;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.Employees.Model
{
    [TestFixture]
    public class EngineerTests
    {
        [Test]
        public void EngineersAreEmployees() => 
            Assert.IsTrue(typeof(Engineer).IsSubclassOf(typeof(Employee)));
        
    }
}