using ARMS.Domain;

namespace ARMS.WebAPI.Dtos
{
    public class CreateEventDto
    {
        public string Name { get; set; }
        public int BeginYear { get; set; }
        public int EndYear { get; set; }
        public string? Description { get; set; }
        public List<CreateCountryDto> Countries { get; set; }
    }
}
