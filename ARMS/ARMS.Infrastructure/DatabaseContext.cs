using ARMS.Application;
using ARMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace ARMS.Infrastructure
{
    public class DatabaseContext: DbContext, IDatabaseContext
    {
        public DbSet<Event> Events => Set<Event>();

        public DbSet<Country> Countries => Set<Country>();
        public DbSet<LifeExpectancy> LifeExpectancies => Set<LifeExpectancy>();

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ARMS.db");
        }
    }
}
