using Microsoft.Extensions.Configuration;

namespace XSwift.Settings
{
    /// <summary>
    /// Represents settings related to an in-memory database.
    /// </summary>
    public class InMemoryDatabaseSetting
    {
 
        private IConfigurationRoot? _configuration;

        private string? _databaseName;

        /// <summary>
        /// Gets the name of the in-memory database.
        /// </summary>
        public string DatabaseName
        {
            get => _databaseName!;
        }

        /// <summary>
        /// Default constructor for <see cref="InMemoryDatabaseSetting"/>.
        /// </summary>
        public InMemoryDatabaseSetting()
        {
        }

        /// <summary>
        /// Constructor for <see cref="InMemoryDatabaseSetting"/> with configuration provided.
        /// </summary>
        /// <param name="configuration">The configuration values containing in-memory database settings.</param>
        public InMemoryDatabaseSetting(IConfigurationRoot configuration)
        {
            _configuration = configuration;

            _databaseName = _configuration
                .GetSection("InMemoryDatabaseSetting")
                .GetSection("DatabaseName").Value!;
        }

        /// <summary>
        /// Sets the name of the in-memory database.
        /// </summary>
        /// <param name="value">The name to be set for the in-memory database.</param>
        public void SetInMemoryDatabaseName(string value)
        {
            _databaseName = value;
        }
    }
}
