using ARMS.Domain;

namespace ARMS.Application.Repositiories
{
    public interface ICountryRepository
    {
        void Add(Country country);
        void Delete(Country country);
        Country Get(Guid id);
        Boolean Exists(string name);
        Country GetByName(string name);
        List<Country> GetAll();
        void Save();
    }
}