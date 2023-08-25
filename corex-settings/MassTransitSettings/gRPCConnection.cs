using Microsoft.Extensions.Configuration;

namespace CoreX.Settings
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

        public void SetHost(string host)
        {
            _host = host;
        }
        public void SetPort(int port)
        {
            _port = port;
        }
    }
}
