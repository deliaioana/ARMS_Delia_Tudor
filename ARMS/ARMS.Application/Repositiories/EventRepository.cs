using ARMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace ARMS.Application.Repositiories
{
    public class EventRepository : IEventRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public EventRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Event @event)
        {
            _databaseContext.Events.Add(@event);
        }

        public List<Event> GetAll()
        {
            return _databaseContext.Events.Include(e => e.Countries).ToList();
        }

        public Event Get(Guid id)
        {
            return _databaseContext.Events.Include(e => e.Countries).FirstOrDefault(e => e.Id == id);
        }

        public void Delete(Event @event)
        {
            _databaseContext.Events.Remove(@event);
        }

        public void Save()
        {
            _databaseContext.Save();
        }
    }
}
