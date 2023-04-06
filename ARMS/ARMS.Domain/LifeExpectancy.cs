using ARMS.Domain.Helpers;

namespace ARMS.Domain
{
    public class LifeExpectancy
    {
        public Guid Id { get; private set; }
        public int Year { get; private set; }
        public Country CountryField { get; private set; }
        public float MaleLifeExpectancy { get; private set; }
        public float FemaleLifeExpectancy { get; private set; }

        public static Result<LifeExpectancy> Create(int year, Country countryField, float maleLifeExpectancy, float femaleLifeExpectancy)
        {
            if (year < 0)
            {
                return Result<LifeExpectancy>.Failure("Year cannot be negative");
            }

            var create_life = new LifeExpectancy()
            {
                Id = Guid.NewGuid(),
                Year = year,
                CountryField = countryField,
                MaleLifeExpectancy = maleLifeExpectancy,
                FemaleLifeExpectancy = femaleLifeExpectancy
            };

            return Result<LifeExpectancy>.Success(create_life);
        }
    }
}
