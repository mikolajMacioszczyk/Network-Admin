using NetworkAdmin.IpAddress.Ipv4;

namespace NetworkAdmin.IpAddress.Range.IPv4
{
    public static class Ipv4RangeResolver
    {
        public static IPRange<Ipv4Address> Resolve(Ipv4Address address)
        {
            if (IsBetween(address, SoftwareMin, SoftwareMax))
            {
                return new SoftwareIpv4Range();
            }
            if (IsBetween(address, Private1Min, Private1Max)
                || IsBetween(address, Private2Min, Private2Max)
                || IsBetween(address, Private3Min, Private3Max)
                || IsBetween(address, Private4Min, Private4Max)
                || IsBetween(address, Private5Min, Private5Max))
            {
                return new PrivateIpv4Range();
            }
            if (IsBetween(address, LoopBackMin, LoopBackMax))
            {
                return new LoopbackIpv4Range();
            }
            if (IsBetween(address, LinkLocalMin, LinkLocalMax))
            {
                return new LinkLocalIpv4Range();
            }
            if (IsBetween(address, Ipv6RelayMin, Ipv6RelayMax))
            {
                return new Ipv6Relay();
            }
            if (IsBetween(address, Documentation1Min, Documentation1Max)
                || IsBetween(address, Documentation2Min, Documentation2Max)
                || IsBetween(address, Documentation3Min, Documentation3Max))
            {
                return new DocumentationIpv4Range();
            }
            if (IsBetween(address, MulticastMin, MulticastMax))
            {
                return new MulticastIpv4Range();
            }
            if (IsBetween(address, FutureMin, FutureMax))
            {
                return new FutureIpv4Range();
            }
            if (address == LimitedBroadcast)
            {
                return new LimitedBroadcastIpv4Range();
            }
            return new PublicIpv4Range();
        }

        private static bool IsBetween(Ipv4Address address, Ipv4Address min, Ipv4Address max)
        {
            return address >= min && address <= max;
        }
        
        #region Private Addresses

        private static readonly Ipv4Address SoftwareMin = new Ipv4Address(0,0,0,0);
        private static readonly Ipv4Address SoftwareMax = new Ipv4Address(0,255,255,255);
        
        private static readonly Ipv4Address Private1Min = new Ipv4Address(10,0,0,0);
        private static readonly Ipv4Address Private1Max = new Ipv4Address(10,255,255,255);
        private static readonly Ipv4Address Private2Min = new Ipv4Address(100,64,0,0);
        private static readonly Ipv4Address Private2Max = new Ipv4Address(100,127,255,255);
        private static readonly Ipv4Address Private3Min = new Ipv4Address(192,0,0,0);
        private static readonly Ipv4Address Private3Max = new Ipv4Address(192,0,0,255);
        private static readonly Ipv4Address Private4Min = new Ipv4Address(192,168,0,0);
        private static readonly Ipv4Address Private4Max = new Ipv4Address(192,168,255,255);
        private static readonly Ipv4Address Private5Min = new Ipv4Address(198,18,0,0);
        private static readonly Ipv4Address Private5Max = new Ipv4Address(198, 19, 255, 255);
        
        private static readonly Ipv4Address LoopBackMin = new Ipv4Address(127,0,0,0);
        private static readonly Ipv4Address LoopBackMax = new Ipv4Address(127,255,255,255);
        
        private static readonly Ipv4Address LinkLocalMin = new Ipv4Address(169,254,0,0);
        private static readonly Ipv4Address LinkLocalMax = new Ipv4Address(169,254,255,255);
        
        private static readonly Ipv4Address Documentation1Min = new Ipv4Address(192,0,2,0);
        private static readonly Ipv4Address Documentation1Max = new Ipv4Address(192,0,2,255);
        private static readonly Ipv4Address Documentation2Min = new Ipv4Address(198,51,100,0);
        private static readonly Ipv4Address Documentation2Max = new Ipv4Address(198,51,100,255);
        private static readonly Ipv4Address Documentation3Min = new Ipv4Address(203,0,113,0);
        private static readonly Ipv4Address Documentation3Max = new Ipv4Address(203,0,113,255);
        
        private static readonly Ipv4Address Ipv6RelayMin = new Ipv4Address(192,88,99,0);
        private static readonly Ipv4Address Ipv6RelayMax = new Ipv4Address(192,88,99,255);
        
        private static readonly Ipv4Address MulticastMin = new Ipv4Address(224,0,0,0);    
        private static readonly Ipv4Address MulticastMax = new Ipv4Address(239,255,255,255);
        
        private static readonly Ipv4Address FutureMin = new Ipv4Address(240,0,0,0);    
        private static readonly Ipv4Address FutureMax = new Ipv4Address(255,255,255,254);
        
        private static readonly Ipv4Address LimitedBroadcast = new Ipv4Address(255,255,255,255);

        #endregion
        
        #region Public Accessible Addresses

        public static Ipv4Address SoftwareMinAddress() => new Ipv4Address(0,0,0,0);
        public static Ipv4Address SoftwareMaxAddress() => new Ipv4Address(0,255,255,255);
        public static Ipv4Address Public1MinAddress() => new Ipv4Address(1,0,0,0);
        public static Ipv4Address Public1MaxAddress() => new Ipv4Address(9,255,255,255);
        public static Ipv4Address Private1MinAddress() => new Ipv4Address(10,0,0,0);
        public static Ipv4Address Private1MaxAddress() => new Ipv4Address(10,255,255,255);
        public static Ipv4Address Public2MinAddress() => new Ipv4Address(11,0,0,0);
        public static Ipv4Address Public2MaxAddress() => new Ipv4Address(100,63,255,255);
        public static Ipv4Address Private2MinAddress() => new Ipv4Address(100,64,0,0);
        public static Ipv4Address Private2MaxAddress() => new Ipv4Address(100,127,255,255);
        public static Ipv4Address Public3MinAddress() => new Ipv4Address(100,128,0,0);
        public static Ipv4Address Public3MaxAddress() => new Ipv4Address(126,255,255,255);
        public static Ipv4Address LoopBackMinAddress() => new Ipv4Address(127,0,0,0);
        public static Ipv4Address LoopBackMaxAddress() => new Ipv4Address(127,255,255,255);
        public static Ipv4Address Public4MinAddress() => new Ipv4Address(128,0,0,0);
        public static Ipv4Address Public4MaxAddress() => new Ipv4Address(169,253,255,255);
        public static Ipv4Address LinkLocalMinAddress() => new Ipv4Address(169,254,0,0);
        public static Ipv4Address LinkLocalMaxAddress() => new Ipv4Address(169,254,255,255);
        public static Ipv4Address Public5MinAddress() => new Ipv4Address(169,255,0,0);
        public static Ipv4Address Public5MaxAddress() => new Ipv4Address(191,255,255,255);
        public static Ipv4Address Private3MinAddress() => new Ipv4Address(192,0,0,0);
        public static Ipv4Address Private3MaxAddress() => new Ipv4Address(192,0,0,255);
        public static Ipv4Address Public6MinAddress() => new Ipv4Address(192,0,1,0);
        public static Ipv4Address Public6MaxAddress() => new Ipv4Address(192,0,1,255);
        public static Ipv4Address Documentation1MinAddress() => new Ipv4Address(192,0,2,0);
        public static Ipv4Address Documentation1MaxAddress() => new Ipv4Address(192,0,2,255);
        public static Ipv4Address Public7MinAddress() => new Ipv4Address(192,0,3,0);
        public static Ipv4Address Public7MaxAddress() => new Ipv4Address(192,88,98,255);
        public static Ipv4Address Ipv6RelayMinAddress() => new Ipv4Address(192,88,99,0);
        public static Ipv4Address Ipv6RelayMaxAddress() => new Ipv4Address(192,88,99,255);
        public static Ipv4Address Public8MinAddress() => new Ipv4Address(192,89,0,0);
        public static Ipv4Address Public8MaxAddress() => new Ipv4Address(192,167,255,255);
        public static Ipv4Address Private4MinAddress() => new Ipv4Address(192,168,0,0);
        public static Ipv4Address Private4MaxAddress() => new Ipv4Address(192,168,255,255);
        public static Ipv4Address Public9MinAddress() => new Ipv4Address(192,169,0,0);
        public static Ipv4Address Public9MaxAddress() => new Ipv4Address(198,17,255,255);
        public static Ipv4Address Private5MinAddress() => new Ipv4Address(198,18,0,0);
        public static Ipv4Address Private5MaxAddress() => new Ipv4Address(198, 19, 255, 255);
        public static Ipv4Address Public10MinAddress() => new Ipv4Address(198,20,0,0);
        public static Ipv4Address Public10MaxAddress() => new Ipv4Address(198,51,99,255);
        public static Ipv4Address Documentation2MinAddress() => new Ipv4Address(198,51,100,0);
        public static Ipv4Address Documentation2MaxAddress() => new Ipv4Address(198,51,100,255);
        public static Ipv4Address Public11MinAddress() => new Ipv4Address(198,51,101,0);
        public static Ipv4Address Public11MaxAddress() => new Ipv4Address(198,51,101,05);
        public static Ipv4Address Documentation3MinAddress() => new Ipv4Address(203,0,113,0);
        public static Ipv4Address Documentation3MaxAddress() => new Ipv4Address(203,0,113,255);
        public static Ipv4Address Public12MinAddress() => new Ipv4Address(203,0,114,0);
        public static Ipv4Address Public12MaxAddress() => new Ipv4Address(223,255,255,255);
        public static Ipv4Address MulticastMinAddress() => new Ipv4Address(224,0,0,0);    
        public static Ipv4Address MulticastMaxAddress() => new Ipv4Address(239,255,255,255);
        public static Ipv4Address FutureMinAddress() => new Ipv4Address(240,0,0,0);    
        public static Ipv4Address FutureMaxAddress() => new Ipv4Address(255,255,255,254);
        public static Ipv4Address LimitedBroadcastAddress() => new Ipv4Address(255,255,255,255);

        #endregion
    }
}