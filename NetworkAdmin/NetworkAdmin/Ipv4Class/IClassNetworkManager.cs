using NetworkAdmin.IpAddress.Ipv4;

namespace NetworkAdmin.Ipv4Class
{
    public interface IClassNetworkManager<T> where T: IpAddress.IPAddress
    {
        IClassNetwork<T> GetClass(T address);
        ushort SubnetBitCount(IClassNetwork<T> networkClass, ushort networkPortion);
        ushort HostBitCount(IClassNetwork<T> networkClass, ushort networkPortion);
        bool IsNetworkPortionValid(IClassNetwork<T> networkClass, ushort networkPortion);
    }
}