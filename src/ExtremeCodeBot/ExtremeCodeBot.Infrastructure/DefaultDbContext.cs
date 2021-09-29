using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ExtremeCodeBot.Infrastructure
{
    public class DefaultDbContext : DbContext
    {
        private readonly string _connectionString;

        public DefaultDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}