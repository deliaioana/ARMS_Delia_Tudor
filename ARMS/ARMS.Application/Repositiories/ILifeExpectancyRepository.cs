using ARMS.Domain;

namespace ARMS.Application.Repositiories
{
    public interface ILifeExpectancyRepository
    {
        void Add(LifeExpectancy lifeExpectancy);
        void Delete(LifeExpectancy lifeExpectancy);
        LifeExpectancy Get(Guid id);
        List<LifeExpectancy> GetAll();
        void Save();
    }
}