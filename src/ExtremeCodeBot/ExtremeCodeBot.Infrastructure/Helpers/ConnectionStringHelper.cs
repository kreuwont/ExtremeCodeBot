using ExtremeCodeBot.Infrastructure.Settings;
using Npgsql;

namespace ExtremeCodeBot.Infrastructure.Helpers
{
    public static class ConnectionStringHelper
    {
        public static string GetConnectionString(DbSettings settings)
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = settings.Host,
                Port = settings.Port,
                Database = settings.DbName,
                Username = settings.User,
                Password = settings.Password,
                SearchPath = settings.Schema,
                MaxPoolSize = settings.MaxPoolSize,
                NoResetOnClose = true,
            };

            return connectionStringBuilder.ConnectionString;
        }
    }
}