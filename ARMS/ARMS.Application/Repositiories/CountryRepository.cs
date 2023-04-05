using ARMS.Domain;

namespace ARMS.Application.Repositiories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public CountryRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Country country)
        {
            _databaseContext.Countries.Add(country);
        }

        public List<Country> GetAll()
        {
            return _databaseContext.Countries.ToList();
        }

        public Country Get(Guid id)
        {
            return _databaseContext.Countries.FirstOrDefault(e => e.Id == id);
        }

        public Boolean Exists(string name)
        {
            return _databaseContext.Countries.Where(e => e.Name == name).Any();
        }

        public Country GetByName(string name)
        {
            return _databaseContext.Countries.FirstOrDefault(c => c.Name == name);
        }

        public void Delete(Country country)
        {
            _databaseContext.Countries.Remove(country);
        }

        public void Save()
        {
            _databaseContext.Save();
        }
    }
}
