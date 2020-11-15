using System;
using System.Collections.Generic;
using System.Linq;
using NetworkAdmin.IpAddress.Utils;

namespace NetworkAdmin.IpAddress.Ipv4
{
    public class Ipv4Address: IPAddress
    {
        private static readonly IPAddressUtils<Ipv4Address> Utils = new Ipv4AddressUtils();
        public ushort FirstOctet => Utils.GetSingleOctetDecimalFromBinary(Binary.Take(8).ToArray());
        public ushort SecondOctet => Utils.GetSingleOctetDecimalFromBinary(Binary.Skip(8).Take(8).ToArray());
        public ushort ThirdOctet => Utils.GetSingleOctetDecimalFromBinary(Binary.Skip(16).Take(8).ToArray());
        public ushort FourthOctet => Utils.GetSingleOctetDecimalFromBinary(Binary.Skip(24).Take(8).ToArray());

        private bool[] Binary;

        public bool this[int key]
        {
            get => Binary[key];
            set => Binary[key] = value;
        }

        public Ipv4Address(Ipv4Address source): this(source.FirstOctet, source.SecondOctet, source.ThirdOctet, source.FourthOctet)
        { }
        
        public Ipv4Address(bool[] binary)
        {
            Binary = binary;
        }

        public Ipv4Address(ushort firstOctet, ushort secondOctet, ushort thirdOctet, ushort fourthOctet)
        {
            var accum = new List<bool>(32);
            accum.AddRange(Utils.GetSingleOctetBinaryFromDecimal(firstOctet));
            accum.AddRange(Utils.GetSingleOctetBinaryFromDecimal(secondOctet));
            accum.AddRange(Utils.GetSingleOctetBinaryFromDecimal(thirdOctet));
            accum.AddRange(Utils.GetSingleOctetBinaryFromDecimal(fourthOctet));
            Binary = accum.ToArray();
        }

        public bool[] ToBinary()
        {
            bool[] firstOctetBin = Utils.GetSingleOctetBinaryFromDecimal(FirstOctet);
            bool[] secondOctetBin = Utils.GetSingleOctetBinaryFromDecimal(SecondOctet);
            bool[] thirdOctetBin = Utils.GetSingleOctetBinaryFromDecimal(ThirdOctet);
            bool[] fourthOctetBin = Utils.GetSingleOctetBinaryFromDecimal(FourthOctet);
            
            var output = new List<bool>(32);
            output.AddRange(firstOctetBin);
            output.AddRange(secondOctetBin);
            output.AddRange(thirdOctetBin);
            output.AddRange(fourthOctetBin);
            return output.ToArray();
        }

        public ushort[] ToDecimal()
        {
            return new[] {FirstOctet, SecondOctet, ThirdOctet, FourthOctet};
        }

        public string ToDecimalString()
        {
            return FirstOctet + "." + SecondOctet + "." + ThirdOctet + "." + FourthOctet;
        }
        
        public string ToBinaryString()
        {
            return Utils.BinaryIpToString(Binary);
        }

        #region operators

        public static bool operator<(Ipv4Address first, Ipv4Address second)
        {
            for (int i = 0; i < 32; i++)
            {
                if (!first.Binary[i] && second.Binary[i])
                {
                    return true;
                }
                if (first.Binary[i] && !second.Binary[i])
                {
                    return false;
                }
            }
            return false;
        } 
        public static bool operator>(Ipv4Address first, Ipv4Address second)
        {
            return second < first;
        }
        
        public static bool operator<=(Ipv4Address first, Ipv4Address second)
        {
            for (int i = 0; i < 32; i++)
            {
                if (!first.Binary[i] && second.Binary[i])
                {
                    return true;
                }
                if (first.Binary[i] && !second.Binary[i])
                {
                    return false;
                }
            }
            return true;
        }
        
        public static bool operator>=(Ipv4Address first, Ipv4Address second)
        {
            return second <= first;
        }
        
        public static bool operator==(Ipv4Address first, Ipv4Address second)
        {
            if (ReferenceEquals(second, null) || ReferenceEquals(first, null)) return false;
            return second.ToDecimal().SequenceEqual(first.ToDecimal());
        }
        
        public static bool operator!=(Ipv4Address first, Ipv4Address second)
        {
            return !(first == second);
        }

        #endregion
    }
}