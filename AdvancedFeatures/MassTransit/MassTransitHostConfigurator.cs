using MassTransit;
using MassTransit.RabbitMqTransport;

namespace Artaco.Infrastructure.CoreX
{
    public static class MassTransitHostConfigurator
    {
        public static void AddHost(
            this IRabbitMqBusFactoryConfigurator config,
            MassTransitConnection connection)
        {
            var hostAddress = new Uri(
                $"rabbitmq://" +
                $"{connection.Domain}/" +
                $"{connection.Host}");

            config.Host(hostAddress, hst =>
            {
                hst.Username(connection.Username);
                hst.Password(connection.Password);
            });
        }
    }
}
