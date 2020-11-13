using NetworkAdmin.IpAddress.Ipv4;

namespace NetworkAdmin.Network
{
    public interface INetworkManager<T> where T: IpAddress.IPAddress
    {
        public T GetBroadcastAddress(Ipv4Address hostAddress, ushort networkPortion);

        public T GetNetworkAddress(Ipv4Address hostAddress, ushort networkPortion);

        public Ipv4Address GetFirstHostAddress(Ipv4Address address, ushort networkPortion);

        public Ipv4Address GetLastHostAddress(Ipv4Address address, ushort networkPortion);

        public T GetAddressFromDecimalString(string input);
        public T GetAddressFromBinaryString(string input);
    }
}