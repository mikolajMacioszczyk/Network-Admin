using System;
using NetworkAdmin.Converters.StringToIpv4;
using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.Ipv4Class;
using NetworkAdmin.Ipv4Class.Ipv4;

namespace NetworkAdmin.Network
{
    public class Ipv4NetworkManager: INetworkManager<Ipv4Address>
    {
        private static readonly IClassNetworkManager<Ipv4Address> ClassNetworkManager = new Ipv4ClassNetworkManager();
        private static readonly IStringToIpv4Converter Converter = new StringToIpv4Converter();
        public static readonly ushort IPV6_BIT_COUNT = 32;

        public Ipv4Address GetAddressFromDecimalString(string input)
        {
            return Converter.ConvertFromDecimal(input);
        }

        public Ipv4Address GetAddressFromBinaryString(string input)
        {
            return Converter.ConvertFromBinary(input);
        }
        
        public Ipv4Address GetNetworkAddress(Ipv4Address hostAddress, ushort networkPortion)
        {
            var output = new Ipv4Address(hostAddress);
            return GetClassAOrBOrCSpecialAddress(output, false, false, networkPortion);
        }

        public Ipv4Address GetBroadcastAddress(Ipv4Address hostAddress, ushort networkPortion)
        {
            var output = new Ipv4Address(hostAddress);
            return GetClassAOrBOrCSpecialAddress(output, true, true, networkPortion);
        }

        public Ipv4Address GetFirstHostAddress(Ipv4Address address, ushort networkPortion)
        {
            var output = new Ipv4Address(address);
            return GetClassAOrBOrCSpecialAddress(output, false, true, networkPortion);
        }
        
        public Ipv4Address GetLastHostAddress(Ipv4Address address, ushort networkPortion)
        {
            var output = new Ipv4Address(address);
            return GetClassAOrBOrCSpecialAddress(output, true, false, networkPortion);
        }

        private Ipv4Address GetClassAOrBOrCSpecialAddress(Ipv4Address address, bool fillBits, bool lastBit, ushort networkPortion)
        {
            var netClass = ClassNetworkManager.GetClass(address);
            switch (netClass)
            {
                case ClassA _:
                case ClassB _:
                case ClassC _:
                    FillBits(address,networkPortion,fillBits);
                    address[IPV6_BIT_COUNT - 1] = lastBit;
                    break;
            }
            return address;
        }

        private void FillBits(Ipv4Address address, ushort from, bool value)
        {
            for (ushort i = from; i < IPV6_BIT_COUNT; i++)
            {
                address[i] = value;
            }
        }
    }
}