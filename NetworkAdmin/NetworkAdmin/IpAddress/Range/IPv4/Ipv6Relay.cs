using System.Collections.Generic;
using NetworkAdmin.IpAddress.Ipv4;

using static NetworkAdmin.IpAddress.Range.IPv4.Ipv4RangeResolver;

namespace NetworkAdmin.IpAddress.Range.IPv4
{
    public class Ipv6Relay: Ipv4Range
    {
        public override IEnumerable<(Ipv4Address, Ipv4Address)> GetBoundaries()
        {
            return new[]
            {
                (Ipv6RelayMinAddress(), Ipv6RelayMaxAddress())
            };
        }

        public override string Type()
        {
            return "Ipv6 Relay";
        }
    }
}