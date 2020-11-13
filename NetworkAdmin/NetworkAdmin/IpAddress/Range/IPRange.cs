using System.Collections.Generic;
using NetworkAdmin.IpAddress.Ipv4;

namespace NetworkAdmin.IpAddress.Range
{
    public interface IPRange<T> where T : IPAddress
    {
        IEnumerable<(Ipv4Address, Ipv4Address)> GetBoundaries();
        string Type();
    }
}