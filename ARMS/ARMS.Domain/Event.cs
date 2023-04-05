using ARMS.Domain.Helpers;

namespace ARMS.Domain
{
    public class Event
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public int? BeginYear { get; private set; }
        public int? EndYear { get; private set; }
        public string? Description { get; private set; }
        public List<Country> Countries { get; private set; }

        public static Result<Event> Create(string name, int beginYear, int endYear, string description, List<Country> countries)
        {
            if(name == null)
            {
                return Result<Event>.Failure("Name cannot be null");
            }

            var create_event = new Event()
            {
                Id = Guid.NewGuid(),
                Name = name,
                BeginYear = beginYear,
                EndYear = endYear,
                Description = description,
                Countries = countries
            };

            return Result<Event>.Success(create_event);
        }
    }
}
