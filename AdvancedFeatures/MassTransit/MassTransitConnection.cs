using Microsoft.Extensions.Configuration;

namespace Artaco.Infrastructure.CoreX
{
    public class MassTransitConnection
    {
        public MassTransitConnection(string domain, string host, string username, string password)
        {
            Domain = domain;
            Host = host;
            Username = username;
            Password = password;
        }

        public string Domain { get; private set; }
        public string Host { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public MassTransitConnection(ConfigurationManager configuration)
        {
            if (string.IsNullOrWhiteSpace(configuration.GetSection("MassTransitConnection").GetSection("Domain").Value))
                throw new ArgumentException("There is not 'Domain' section for 'MassTransitConnection' section in appsettings.json");

            if (string.IsNullOrWhiteSpace(configuration.GetSection("MassTransitConnection").GetSection("Host").Value))
                throw new ArgumentException("There is not 'Host' section for 'MassTransitConnection' section in appsettings.json");

            if (string.IsNullOrWhiteSpace(configuration.GetSection("MassTransitConnection").GetSection("Username").Value))
                throw new ArgumentException("There is not 'Username' section for 'MassTransitConnection' section in appsettings.json");

            if (string.IsNullOrWhiteSpace(configuration.GetSection("MassTransitConnection").GetSection("Password").Value))
                throw new ArgumentException("There is not 'Password' section for 'MassTransitConnection' section in appsettings.json");

            Domain = configuration.GetSection("MassTransitConnection").GetSection("Domain").Value;
            Host = configuration.GetSection("MassTransitConnection").GetSection("Host").Value;
            Username = configuration.GetSection("MassTransitConnection").GetSection("Username").Value;
            Password = configuration.GetSection("MassTransitConnection").GetSection("Password").Value;
        }
    }
}
