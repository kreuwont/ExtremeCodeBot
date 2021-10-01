using System.Reflection;
using ExtremeCodeBot.Domain.Aggregates.ClientAggregate;
using ExtremeCodeBot.Domain.Aggregates.PoolAggregate;
using ExtremeCodeBot.Domain.Aggregates.WalletAggregate;
using Microsoft.EntityFrameworkCore;

namespace ExtremeCodeBot.Infrastructure
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Pool> Pools { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}