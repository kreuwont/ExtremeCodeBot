using Npgsql;

namespace ExtremeCodeBot.Infrastructure.Settings
{
    public class DbSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string DbName { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Schema { get; set; }
        public int MaxPoolSize { get; set; }
        
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