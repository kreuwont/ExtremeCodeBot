using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ExtremeCodeBot.Infrastructure
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }
   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}