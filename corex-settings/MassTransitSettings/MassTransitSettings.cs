using Microsoft.Extensions.Configuration;

namespace CoreX.Settings
{
    public enum MassTransitTransportType
    {
        InMemory,
        gRPC,
        RabbitMQ
    }
    public class MassTransitSettings
    {
        public MassTransitTransportType UsingBy { get; private set; } = MassTransitTransportType.InMemory;
        public gRPCConnection gRPCConnection { get; private set; }
        public RabbitMQConnection RabbitMQConnection { get; private set; }

        public MassTransitSettings(IConfigurationRoot configuration)
        {
            Enum.TryParse(configuration.
                GetSection("MasstransitSettings")
                .GetSection("UsingBy").Value,
                out MassTransitTransportType usingBy);
            UsingBy = usingBy;

            gRPCConnection = new gRPCConnection(configuration);
            RabbitMQConnection = new RabbitMQConnection(configuration);
        }
    }
}
