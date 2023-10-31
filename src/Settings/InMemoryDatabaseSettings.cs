using Microsoft.Extensions.Configuration;

namespace XSwift.Settings
{
    public class InMemoryDatabaseSettings
    {
 
        private IConfigurationRoot? _configuration;

        private string? _databaseName;
        public string DatabaseName
        {
            get => _databaseName!;
        }

        public InMemoryDatabaseSettings()
        {
        }
        public InMemoryDatabaseSettings(IConfigurationRoot configuration)
        {
            _configuration = configuration;

            _databaseName = _configuration
                .GetSection("InMemoryDatabaseSettings")
                .GetSection("DatabaseName").Value!;
        }

        public void SetInMemoryDatabaseName(string value)
        {
            _databaseName = value;
        }
    }
}
