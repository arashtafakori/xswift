using Microsoft.Extensions.Configuration;

namespace XSwift.Settings
{
    public class gRPCConnection
    {
        public string? _host;
        public string Host { get => _host!; }

        public int _port;
        public int Port { get => _port; }

        public gRPCConnection()
        {
        }
        public gRPCConnection(IConfigurationRoot configuration)
        {
            var gRPCSection = configuration.
                GetSection("MasstransitSettings")
                .GetSection("Connections")
                .GetSection("gRPC");

            _host = gRPCSection.GetSection("Host").Value!;
            _port = int.Parse(gRPCSection.GetSection("Port").Value!);
        }

        public void SetHost(string value)
        {
            _host = value;
        }
        public void SetPort(int value)
        {
            _port = value;
        }
    }
}
