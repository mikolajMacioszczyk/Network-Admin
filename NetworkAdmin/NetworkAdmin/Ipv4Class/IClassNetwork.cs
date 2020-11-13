namespace NetworkAdmin.Ipv4Class
{
    public interface IClassNetwork<T> where T: IpAddress.IPAddress
    {
        string GetName();
        ushort GetNetworkPortion();
    }
}