using CoreX.Settings;

namespace MassTransit.CoreX
{
    public static class MassTransitConfigurator
    {
        public static void ConfigureBasedOnSettings(
            this IBusRegistrationConfigurator serviceConfigurator,
            MassTransitSettings massTransitSettings,
            Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> configure = null
            )
        {
            if (massTransitSettings.UsingBy == MassTransitTransportType.InMemory)
            {
            }
            else if (massTransitSettings.UsingBy == MassTransitTransportType.RabbitMQ)
            {
                serviceConfigurator.UsingRabbitMq((context, cfg) =>
                {
                    var hostAddress = new Uri(
                        $"rabbitmq://" +
                        $"{massTransitSettings.RabbitMQConnection.Domain}/" +
                        $"{massTransitSettings.RabbitMQConnection.Host}");

                    cfg.Host(hostAddress, hst =>
                    {
                        hst.Username(massTransitSettings.RabbitMQConnection.Username);
                        hst.Password(massTransitSettings.RabbitMQConnection.Password);
                    });

                    configure?.Invoke(context, cfg);
                });
            }
            else if (massTransitSettings.UsingBy == MassTransitTransportType.gRPC)
            {
                serviceConfigurator.UsingGrpc((context, cfg) =>
                {
                    cfg.Host(h =>
                    {
                        h.Host = massTransitSettings.gRPCConnection.Host;
                        h.Port = massTransitSettings.gRPCConnection.Port;
                    });

                    cfg.ConfigureEndpoints(context);
                });
            }
        }
    }
}
