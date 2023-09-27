using Microsoft.Extensions.Configuration;

namespace XSwift.Settings
{
    public enum DatabaseType
    {
        InMemory,
        SqlServer,
        MongoDb
    }
    public class DatabaseSettings
    {
 
        private IConfigurationRoot? _configuration;

        private DatabaseType _type = DatabaseType.InMemory;
        public DatabaseType Type { get => _type; }

        private string? _inMemoryDatabaseName;
        public string InMemoryDatabaseName
        {
            get => _inMemoryDatabaseName!;
        }

        public string? _sqlServerConnectString;
        public string SqlServerConnectString
        {
            get => _sqlServerConnectString!;
        }

        public string? _mongoBdConnectString;
        public string MongoBdConnectString
        {
            get => _mongoBdConnectString!;
        }

        public DatabaseSettings()
        {

        }
        public DatabaseSettings(IConfigurationRoot configuration)
        {
            _configuration = configuration;

            Enum.TryParse(configuration.
                GetSection("DatabaseSettings")
                .GetSection("Type").Value,
                out DatabaseType type);
            _type = type;

            _inMemoryDatabaseName = _configuration
                .GetSection("DatabaseSettings")
                .GetSection("ConnectionStrings")
                .GetSection("InMemoryDatabaseName").Value!;

            _sqlServerConnectString = _configuration
                .GetSection("DatabaseSettings")
                .GetSection("ConnectionStrings")
                .GetSection("SqlServer").Value!;

            _mongoBdConnectString = _configuration
                .GetSection("DatabaseSettings")
                .GetSection("ConnectionStrings")
                .GetSection("MongoDB").Value!;
        }

        public void SetType(DatabaseType type)
        {
            _type = type;
        }
        public void SetInMemoryDatabaseName(string databaseName)
        {
            _inMemoryDatabaseName = databaseName;
        }

        public void SetSqlServerConnectString(string connectionString)
        {
            _sqlServerConnectString = connectionString;
        }
        public void SetMongoBdConnectString(string connectionString)
        {
            _mongoBdConnectString = connectionString;
        }
    }
}
