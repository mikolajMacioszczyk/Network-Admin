using System.Collections.Generic;
using NetworkAdmin.IpAddress.Ipv4;

using static NetworkAdmin.IpAddress.Range.IPv4.Ipv4RangeResolver;

namespace NetworkAdmin.IpAddress.Range.IPv4
{
    public class DocumentationIpv4Range: Ipv4Range
    {
        public override IEnumerable<(Ipv4Address, Ipv4Address)> GetBoundaries()
        {
            return new[]
            {
                (Documentation1MinAddress(), Documentation1MaxAddress()),
                (Documentation2MinAddress(), Documentation2MaxAddress()),
                (Documentation3MinAddress(), Documentation3MaxAddress()),
            };
        }

        public override string Type()
        {
            return "Documentation";
        }
    }
}