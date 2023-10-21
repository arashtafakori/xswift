using Microsoft.Extensions.Configuration;

namespace XSwift.Settings
{
    public class RabbitMQConnection
    {
        public string? _domain;
        public string Domain { get => _domain!; }

        public string? _host;
        public string Host { get => _host!; }

        public string? _username;
        public string Username { get => _username!; }

        public string? _password;
        public string Password { get => _password!; }

        public RabbitMQConnection()
        {
        }
        public RabbitMQConnection(IConfigurationRoot configuration)
        {
            var rabbitMQSection = configuration.
                GetSection("MasstransitSettings")
                .GetSection("Connections")
                .GetSection("RabbitMQ");

            _domain = rabbitMQSection.GetSection("Domain").Value!;
            _host = rabbitMQSection.GetSection("Host").Value!;
            _username = rabbitMQSection.GetSection("Username").Value!;
            _password = rabbitMQSection.GetSection("Password").Value!;
        }

        public void SetDomain(string value)
        {
            _domain = value;
        }

        public void SetHost(string value)
        {
            _host = value;
        }

        public void SetUsername(string value)
        {
            _username = value;
        }

        public void SetPassword(string value)
        {
            _password = value;
        }
    }
}
