using ARMS.Application.Repositiories;
using ARMS.Domain;
using ARMS.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ARMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ICountryRepository _countryRepository;

        public EventsController(IEventRepository eventRepository, ICountryRepository countryRepository)
        {
            _eventRepository = eventRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateEventDto eventDto)
        {
            List<Country> countries = new List<Country>();

            foreach(var country in eventDto.Countries)
            {
                if (!_countryRepository.Exists(country.Name))
                {
                    var countryResult = Country.Create(country.Name);

                    if (countryResult.IsFailure)
                    {
                        return BadRequest(countryResult.Error);
                    }

                    _countryRepository.Add(countryResult.Entity);
                    _countryRepository.Save();
                }
                countries.Add(_countryRepository.GetByName(country.Name));
            }

            var eventResult = Event.Create(eventDto.Name, eventDto.BeginYear, eventDto.EndYear, eventDto.Description, countries);

            if (eventResult.IsFailure)
            {
                return BadRequest(eventResult.Error);
            }

            _eventRepository.Add(eventResult.Entity);
            _eventRepository.Save();

            return Ok(eventResult.Entity);
        }
    }
}
