﻿using Microsoft.Extensions.Configuration;

namespace XSwift.Settings
{
    public enum MassTransitTransportType
    {
        InMemory,
        gRPC,
        RabbitMQ
    }
    public class MassTransitSettings
    {
        private MassTransitTransportType _type = MassTransitTransportType.InMemory;
        public MassTransitTransportType Type { get => _type; }

        private gRPCConnection? _gRPCConnection;
        public gRPCConnection gRPCConnection { get => _gRPCConnection!; }

        public RabbitMQConnection? _rabbitMQConnection;
        public RabbitMQConnection RabbitMQConnection { get => _rabbitMQConnection!; }

        public MassTransitSettings()
        {
        }
        public MassTransitSettings(IConfigurationRoot configuration)
        {
            Enum.TryParse(configuration.
                GetSection("MasstransitSettings")
                .GetSection("Type").Value,
                out MassTransitTransportType type);
            _type = type;

            _gRPCConnection = new gRPCConnection(configuration);
            _rabbitMQConnection = new RabbitMQConnection(configuration);
        }

        public void SetType(MassTransitTransportType value)
        {
            _type = value;
        }

        public void SetgRPCConnection(gRPCConnection value)
        {
            _gRPCConnection = value;
        }

        public void SetRabbitMQConnection(RabbitMQConnection value)
        {
            _rabbitMQConnection = value;
        }
    }
}
