using ARMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace ARMS.Application
{
    public interface IDatabaseContext
    {
        public DbSet<Event> Events { get; }
        public DbSet<Country> Countries { get; }
        public DbSet<LifeExpectancy> LifeExpectancies { get; }

        void Save();
    }
}
