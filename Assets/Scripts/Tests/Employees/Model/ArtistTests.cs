using Employees.Model;
using NUnit.Framework;
using static Employees.Model.Currency;
using static Employees.Model.Seniority;

namespace Tests.Employees.Model
{
    [TestFixture]
    public class ArtistTests
    {
        Artist artist;
        
        [Test]
        public void ArtistAreEmployees() => 
            Assert.IsTrue(typeof(Artist).IsSubclassOf(typeof(Employee)));

        [Test]
        [TestCase(Semi_Senior, 1200, DOLLARS)]
        [TestCase(Senior, 2000, DOLLARS)]
        public void ArtistsBaseSalaryDependsOfTheSeniority(Seniority seniority, int amount, Currency currency)
        {
            GivenAnArtistWithSeniority(seniority);
            ThenArtistSalaryIs(new Salary(amount, currency));
        }

        [Test]
        [TestCase(Semi_Senior, 2.5f)]
        [TestCase(Senior, 5f)]
        public void ArtistsHaveASalaryIncrementPercentageBasedOfTheSeniority(Seniority seniority, float percentage)
        {
            GivenAnArtistWithSeniority(seniority);
            var initialSalaryAmount = artist.GetSalary().Amount;
            WhenAppliedSalaryIncrement();
            ThenSalaryAmountIs(initialSalaryAmount * 0.01f * percentage + initialSalaryAmount);
        }

        void GivenAnArtistWithSeniority(Seniority seniority) => 
            artist = new Artist(seniority);
        
        void WhenAppliedSalaryIncrement() => 
            artist.ApplySalaryIncrement();

        void ThenArtistSalaryIs(Salary salary) => 
            Assert.AreEqual(artist.GetSalary(), salary);

        void ThenSalaryAmountIs(float expectedSalaryAmount) =>
            Assert.AreEqual(artist.GetSalary().Amount, expectedSalaryAmount);
    }
}