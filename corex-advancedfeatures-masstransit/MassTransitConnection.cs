using Microsoft.Extensions.Configuration;

namespace CoreX.AdvancedFeatures.MassTransit
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

        public MassTransitConnection(IConfigurationSection section)
        {
            Domain = section.GetSection("Domain").Value;
            Host = section.GetSection("Host").Value;
            Username = section.GetSection("Username").Value;
            Password = section.GetSection("Password").Value;
        }
    }
}
