using System.Collections.Generic;
using NetworkAdmin.IpAddress.Ipv4;

using static NetworkAdmin.IpAddress.Range.IPv4.Ipv4RangeResolver;

namespace NetworkAdmin.IpAddress.Range.IPv4
{
    public class PublicIpv4Range: Ipv4Range
    {
        public override IEnumerable<(Ipv4Address, Ipv4Address)> GetBoundaries()
        {
            return new[]
            {
                (Public1MinAddress(), Public1MaxAddress()),
                (Public2MinAddress(), Public2MaxAddress()),
                (Public3MinAddress(), Public3MaxAddress()),
                (Public4MinAddress(), Public4MaxAddress()),
                (Public5MinAddress(), Public5MaxAddress()),
                (Public6MinAddress(), Public6MaxAddress()),
                (Public7MinAddress(), Public7MaxAddress()),
                (Public8MinAddress(), Public8MaxAddress()),
                (Public9MinAddress(), Public9MaxAddress()),
                (Public10MinAddress(), Public10MaxAddress()),
                (Public11MinAddress(), Public11MaxAddress()),
                (Public12MinAddress(), Public12MaxAddress()),
            };
        }

        public override string Type()
        {
            return "Public";
        }
    }
}