using System.Collections.Generic;
using NetworkAdmin.IpAddress.Ipv4;
using static NetworkAdmin.IpAddress.Range.IPv4.Ipv4RangeResolver;

namespace NetworkAdmin.IpAddress.Range.IPv4
{
    public class SoftwareIpv4Range: Ipv4Range
    {
        public override IEnumerable<(Ipv4Address, Ipv4Address)> GetBoundaries()
        {
            return new[] {(SoftwareMinAddress(), SoftwareMaxAddress())};
        }

        public override string Type()
        {
            return "Software";
        }
    }
}