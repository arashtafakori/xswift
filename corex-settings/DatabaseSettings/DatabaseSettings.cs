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
        public DatabaseType UsingBy { get; private set; } = DatabaseType.InMemory;
        public string SqlServerConnectString { get; private set; } = string.Empty;
        public string MongoBdConnectString { get; private set; } = string.Empty;

        public DatabaseSettings(IConfigurationRoot configuration)
        {
            Enum.TryParse(configuration.
                GetSection("DatabaseStrings")
                .GetSection("UsingBy").Value,
                out DatabaseType usingBy);
            UsingBy = usingBy;

            SqlServerConnectString = configuration
                .GetSection("DatabaseStrings")
                .GetSection("ConnectionStrings")
                .GetSection("SqlServer").Value!;

            SqlServerConnectString = configuration
                .GetSection("DatabaseStrings")
                .GetSection("ConnectionStrings")
                .GetSection("MongoDB").Value!;
        }
    }
}
