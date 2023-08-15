using Microsoft.Extensions.Configuration;

namespace CoreX.Settings
{
    public enum DatabaseType
    {
        InMemory,
        SqlServer,
        MongoDb
    }
    public class DatabaseSettings
    {
 
        private IConfigurationRoot _configuration;
        public DatabaseType UsingBy { get; private set; } = DatabaseType.InMemory;
        public string? SqlServerConnectString
        {
            get => _configuration
                    .GetSection("DatabaseSettings")
                    .GetSection("ConnectionStrings")
                    .GetSection("SqlServer").Value!
                ?? throw new InvalidOperationException("Connection string not found.");
        }
        public string? MongoBdConnectString
        {
            get => _configuration
                .GetSection("DatabaseSettings")
                .GetSection("ConnectionStrings")
                .GetSection("MongoDB").Value!
                ?? throw new InvalidOperationException("Connection string not found.");
        }

        public DatabaseSettings(IConfigurationRoot configuration)
        {
            _configuration = configuration;

            Enum.TryParse(configuration.
                GetSection("DatabaseSettings")
                .GetSection("UsingBy").Value,
                out DatabaseType usingBy);
            UsingBy = usingBy;
        }
    }
}
