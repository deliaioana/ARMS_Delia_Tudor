using ARMS.Domain.Helpers;

namespace ARMS.Domain
{
    public class Country
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }

        public static Result<Country> Create(string name)
        {
            if (name == null)
            {
                return Result<Country>.Failure("Name cannot be null");
            }

            var country = new Country
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            return Result<Country>.Success(country);
        }
    }
}
