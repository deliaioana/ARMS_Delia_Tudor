using ARMS.Application.Repositiories;
using ARMS.Domain;
using ARMS.WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_countryRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateCountryDto countryDto)
        {
            if (_countryRepository.Exists(countryDto.Name))
            {
                var country = _countryRepository.GetByName(countryDto.Name);
                return Ok(country);
            }

            var countryResult = Country.Create(countryDto.Name);

            if (countryResult.IsFailure)
            {
                return BadRequest(countryResult.Error);
            }

            _countryRepository.Add(countryResult.Entity);
            _countryRepository.Save();
            return Ok(countryResult.Entity);
        }
    }
}
