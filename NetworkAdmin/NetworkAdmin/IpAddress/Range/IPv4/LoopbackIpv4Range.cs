using System.Collections.Generic;
using NetworkAdmin.IpAddress.Ipv4;
using static NetworkAdmin.IpAddress.Range.IPv4.Ipv4RangeResolver;

namespace NetworkAdmin.IpAddress.Range.IPv4
{
    public class LoopbackIpv4Range: Ipv4Range
    {
        public override IEnumerable<(Ipv4Address, Ipv4Address)> GetBoundaries()
        {
            return new[] {(LoopBackMinAddress(), LoopBackMaxAddress())};
        }

        public override string Type()
        {
            return "Loopback";
        }
    }
}