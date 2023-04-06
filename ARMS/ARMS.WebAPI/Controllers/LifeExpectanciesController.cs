using ARMS.Application.Repositiories;
using ARMS.Domain;
using ARMS.WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeExpectanciesController : ControllerBase
    {
        private readonly ILifeExpectancyRepository _lifeExpectancyRepository;
        private readonly ICountryRepository _countryRepository;

        public LifeExpectanciesController(ILifeExpectancyRepository lifeExpectancyRepository, ICountryRepository countryRepository)
        {
            _lifeExpectancyRepository = lifeExpectancyRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_lifeExpectancyRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateLifeExpectancyDto lifeExpectancyDto)
        {
            if (!_countryRepository.Exists(lifeExpectancyDto.CountryName))
            {
                var countryResult = Country.Create(lifeExpectancyDto.CountryName);

                if (countryResult.IsFailure)
                {
                    return BadRequest(countryResult.Error);
                }

                _countryRepository.Add(countryResult.Entity);
                _countryRepository.Save();
            }
            var country = _countryRepository.GetByName(lifeExpectancyDto.CountryName);

            var lifeExpectancyResult = LifeExpectancy.Create(lifeExpectancyDto.Year, country, lifeExpectancyDto.MaleLifeExpectancy, lifeExpectancyDto.FemaleLifeExpectancy);

            if (lifeExpectancyResult.IsFailure)
            {
                return BadRequest(lifeExpectancyResult.Error);
            }

            _lifeExpectancyRepository.Add(lifeExpectancyResult.Entity);
            _lifeExpectancyRepository.Save();

            return Ok(lifeExpectancyResult.Entity);
        }
    }
}
