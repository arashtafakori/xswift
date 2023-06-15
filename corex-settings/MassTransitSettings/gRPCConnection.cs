using Microsoft.Extensions.Configuration;

namespace CoreX.Settings
{
    public class gRPCConnection
    {
        public string Host { get; private set; }
        public int Port { get; private set; }

        public gRPCConnection(IConfigurationRoot configuration)
        {
            var gRPCSection = configuration.
                GetSection("MasstransitSettings")
                .GetSection("Connections")
                .GetSection("gRPC");

            Host = gRPCSection.GetSection("Host").Value!;
            Port = int.Parse(gRPCSection.GetSection("Port").Value!);
        }
    }
}
