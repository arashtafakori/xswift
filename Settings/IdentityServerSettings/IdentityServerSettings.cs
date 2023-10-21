using Microsoft.Extensions.Configuration;

namespace XSwift.Settings
{
    public class IdentityServerSettings
    {
        private IConfigurationRoot? _configuration;

        private string? _authority;
        public string Authority
        {
            get => _authority!;
        }

        private string? _clientId;
        public string ClientId
        {
            get => _clientId!;
        }
        private string? _clientSecret;
        public string ClientSecret
        {
            get => _clientSecret!;
        }
        public IdentityServerSettings() { }

        public IdentityServerSettings(IConfigurationRoot configuration)
        {
            _configuration = configuration;

            _authority = _configuration
                .GetSection("IdentityServerSettings")
                .GetSection("Authority").Value!;

            _clientId = _configuration
                .GetSection("IdentityServerSettings")
                .GetSection("ClientId").Value!;

            _clientSecret = _configuration
                .GetSection("IdentityServerSettings")
                .GetSection("ClientSecret").Value!;
        }

        public void SetAuthority(string value)
        {
            _authority = value;
        }
    }
}
