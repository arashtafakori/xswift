using Microsoft.Extensions.Configuration;

namespace CoreX.Settings
{
    public class RabbitMQConnection
    {
        public string Domain { get; private set; }
        public string Host { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public RabbitMQConnection(IConfigurationRoot configuration)
        {
            var rabbitMQSection = configuration.
                GetSection("MasstransitSettings")
                .GetSection("Connections")
                .GetSection("RabbitMQ");

            Domain = rabbitMQSection.GetSection("Domain").Value!;
            Host = rabbitMQSection.GetSection("Host").Value!;
            Username = rabbitMQSection.GetSection("Username").Value!;
            Password = rabbitMQSection.GetSection("Password").Value!;
        }
    }
}
