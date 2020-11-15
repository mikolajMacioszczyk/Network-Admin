using NetworkAdmin.IpAddress.Ipv4;

namespace NetworkAdmin.Ipv4Class
{
    public interface IClassNetworkManager<T> where T: IpAddress.IPAddress
    {
        IClassNetwork<T> GetClass(T address);
        ushort SubnetBitCount(IClassNetwork<T> networkClass, ushort networkPortion);
        ushort HostBitCount(IClassNetwork<T> networkClass, ushort networkPortion);
        int PossibleSubnetCount(IClassNetwork<T> networkClass, ushort networkPortion);
        int PossibleHostsCount(IClassNetwork<T> networkClass, in ushort networkPortion);
        bool IsNetworkPortionValid(IClassNetwork<T> networkClass, ushort networkPortion);
    }
}    