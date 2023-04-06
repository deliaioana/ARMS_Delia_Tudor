using ARMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace ARMS.Application.Repositiories
{
    public class LifeExpectancyRepository : ILifeExpectancyRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public LifeExpectancyRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(LifeExpectancy lifeExpectancy)
        {
            _databaseContext.LifeExpectancies.Add(lifeExpectancy);
        }

        public List<LifeExpectancy> GetAll()
        {
            return _databaseContext.LifeExpectancies.Include(e => e.CountryField).ToList();
        }

        public LifeExpectancy Get(Guid id)
        {
            return _databaseContext.LifeExpectancies.Include(e => e.CountryField).FirstOrDefault(e => e.Id == id);
        }

        public void Delete(LifeExpectancy lifeExpectancy)
        {
            _databaseContext.LifeExpectancies.Remove(lifeExpectancy);
        }

        public void Save()
        {
            _databaseContext.Save();
        }
    }
}
