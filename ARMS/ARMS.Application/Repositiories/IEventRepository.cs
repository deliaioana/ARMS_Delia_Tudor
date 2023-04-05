using ARMS.Domain;

namespace ARMS.Application.Repositiories
{
    public interface IEventRepository
    {
        void Add(Event @event);
        void Delete(Event @event);
        Event Get(Guid id);
        List<Event> GetAll();
        void Save();
    }
}