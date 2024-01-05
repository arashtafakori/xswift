using Microsoft.Extensions.Configuration;

namespace XSwift.Settings
{
    /// <summary>
    /// Represents settings related to the database.
    /// </summary>
    public class DatabaseSetting
    {
        private IConfigurationRoot? _configuration;

        private bool _isInMemory;

        /// <summary>
        /// Gets a value indicating whether the database is configured to use an in-memory database.
        /// </summary>
        public bool IsInMemory
        {
            get => _isInMemory!;
        }

        /// <summary>
        /// Default constructor for <see cref="DatabaseSetting"/>.
        /// </summary>
        public DatabaseSetting()
        {
        }

        /// <summary>
        /// Constructor for <see cref="DatabaseSetting"/> with configuration provided.
        /// </summary>
        /// <param name="configuration">The configuration values containing database settings.</param>
        public DatabaseSetting(IConfigurationRoot configuration)
        {
            _configuration = configuration;

            _isInMemory = bool.Parse(_configuration
                .GetSection("DatabaseSetting")
                .GetSection("IsInMemory").Value!);
        }

        /// <summary>
        /// Sets the option indicating whether the database is configured as an in-memory database.
        /// </summary>
        /// <param name="value">The boolean value indicating whether the database is in-memory.</param>
        public void SetIsInMemory(bool value)
        {
            _isInMemory = value;
        }
     }
}
