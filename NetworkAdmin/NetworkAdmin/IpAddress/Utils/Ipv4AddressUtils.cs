using System;
using System.Text;
using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.IpAddress.Range;
using NetworkAdmin.IpAddress.Range.IPv4;
using NetworkAdmin.Ipv4Class;
using NetworkAdmin.Network;

namespace NetworkAdmin.IpAddress.Utils
{
    public class Ipv4AddressUtils : IPAddressUtils<Ipv4Address>
    {
        private static readonly INetworkManager<Ipv4Address> NetworkManager = new Ipv4NetworkManager();
        private static readonly IClassNetworkManager<Ipv4Address> ClassManager = new Ipv4ClassNetworkManager(); 
     
        public bool IsLegalHostAddress(Ipv4Address address, ushort networkPortion)
        {
            var broadcast = NetworkManager.GetBroadcastAddress(address, networkPortion);
            var networkAddress = NetworkManager.GetNetworkAddress(address, networkPortion);
            if (address == broadcast || networkAddress == address)
                return false;
            var networkClass = ClassManager.GetClass(address);
            var networkClassName = networkClass.GetName();
            if (networkClassName == "A" || networkClassName == "B" ||
                networkClassName == "C")
                return ClassManager.IsNetworkPortionValid(networkClass, networkPortion);
            return false;
        }

        public bool IsValidNetworkPortion(Ipv4Address address, int networkPortion)
        {
            var networkClass = ClassManager.GetClass(address);
            switch (networkClass.GetName())
            {
                case "A":
                case "B":
                case "C":
                    return networkPortion >= networkClass.GetNetworkPortion() && networkPortion < 32;
                case "D":
                case "E":
                case "Special":
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public ushort GetSingleOctetDecimalFromBinary(bool[] bits)
        {
            ushort sum = 0;
            ushort power = 1;
            for (int i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i])
                {
                    sum += power;
                }
                power *= 2;
            }
            return sum;
        }    
        
        public bool[] GetSingleOctetBinaryFromDecimal(ushort number)
        {
            bool[] output = new bool[8];
            ushort divider = 128;
            for (int i = 0; i < 8; i++)
            {
                if (number >= divider)
                {
                    output[i] = true;
                    number -= divider;
                }
                divider /= 2;
            }
            return output;
        }
        
        public string BinaryIpToString(bool[] ip)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ip.Length; i++)
            {
                if (i > 0 && i % 8 == 0)
                {
                    sb.Append(".");
                }
                sb.Append(ip[i] ? "1" : "0");
            }
            return sb.ToString();
        }

        public IPRange<Ipv4Address> GetAddressRange(Ipv4Address address)
        {
            return Ipv4RangeResolver.Resolve(address);
        }
    }
}