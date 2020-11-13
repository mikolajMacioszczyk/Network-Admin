using System.Collections.Generic;
using NetworkAdmin.IpAddress.Ipv4;

using static NetworkAdmin.IpAddress.Range.IPv4.Ipv4RangeResolver;

namespace NetworkAdmin.IpAddress.Range.IPv4
{
    public class PrivateIpv4Range: Ipv4Range
    {
        public override IEnumerable<(Ipv4Address, Ipv4Address)> GetBoundaries()
        {
            return new[]
            {
                (Private1MinAddress(),Private1MaxAddress()),
                (Private2MinAddress(),Private2MaxAddress()),
                (Private3MinAddress(),Private3MaxAddress()),
                (Private4MinAddress(),Private4MaxAddress()),
                (Private5MinAddress(),Private5MaxAddress())
            };
        }

        public override string Type()
        {
            return "Private";
        }
    }
}