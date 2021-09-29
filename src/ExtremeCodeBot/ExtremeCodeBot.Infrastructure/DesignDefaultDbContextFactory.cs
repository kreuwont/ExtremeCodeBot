using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExtremeCodeBot.Infrastructure
{
    public class DesignDefaultDbContextFactory : IDesignTimeDbContextFactory<DefaultDbContext>
    {
        public DefaultDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("EXTREMECODE__DEV__DBCONNECTION");

            var optionsBuilder = new DbContextOptionsBuilder<DefaultDbContext>()
                .UseNpgsql(connectionString ?? "blank");

            return new DefaultDbContext(optionsBuilder.Options);
        }
    }
}