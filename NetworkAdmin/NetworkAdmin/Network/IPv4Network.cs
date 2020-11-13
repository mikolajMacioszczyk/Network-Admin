using System.Linq;
using NetworkAdmin.IpAddress;
using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.Ipv4Class;

namespace NetworkAdmin.Network
{
    public class Network
    {
        private static readonly IClassNetworkManager<Ipv4Address> ClassNetworkManager = new Ipv4ClassNetworkManager();
        private static readonly INetworkManager<Ipv4Address> NetworkManager = new Ipv4NetworkManager();
            
        public Ipv4Address Address { get; set; }
        public ushort NetworkPortion { get; set; }

        IpAddress.IPAddress GetBroadCastAddress => NetworkManager.GetBroadcastAddress(Address, NetworkPortion);
        IpAddress.IPAddress GetNetworkAddress => NetworkManager.GetNetworkAddress(Address, NetworkPortion);
        public bool IsNetworkAddress => Address.ToBinary().Skip(NetworkPortion).All(v => !v);
        public bool IsBroadcastAddress => Address.ToBinary().Skip(NetworkPortion).All(v => v);

        public IClassNetwork<Ipv4Address> GetClass()
        {
            return ClassNetworkManager.GetClass(Address);
        }
    }
}