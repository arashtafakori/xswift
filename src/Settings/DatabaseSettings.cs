using Microsoft.Extensions.Configuration;

namespace XSwift.Settings
{
    public class DatabaseSettings
    {
        private IConfigurationRoot? _configuration;

        private bool _isInMemory;
        public bool IsInMemory
        {
            get => _isInMemory!;
        }

        public DatabaseSettings()
        {

        }
        public DatabaseSettings(IConfigurationRoot configuration)
        {
            _configuration = configuration;

            _isInMemory = bool.Parse(_configuration
                .GetSection("DatabaseSettings")
                .GetSection("IsInMemory").Value!);
        }

        public void SetType(bool value)
        {
            _isInMemory = value;
        }
     }
}
