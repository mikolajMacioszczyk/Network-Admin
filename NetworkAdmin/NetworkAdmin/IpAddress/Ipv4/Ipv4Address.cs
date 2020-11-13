using System;
using System.Collections.Generic;
using System.Linq;
using NetworkAdmin.IpAddress.Utils;

namespace NetworkAdmin.IpAddress.Ipv4
{
    public class Ipv4Address: IPAddress
    {
        private static readonly Ipv4AddressUtils Utils = new Ipv4AddressUtils();
        public ushort FirstOctet => Utils.GetDecimalFromBinary(Binary.Take(8).ToArray());
        public ushort SecondOctet => Utils.GetDecimalFromBinary(Binary.Skip(8).Take(8).ToArray());
        public ushort ThirdOctet => Utils.GetDecimalFromBinary(Binary.Skip(16).Take(8).ToArray());
        public ushort FourthOctet => Utils.GetDecimalFromBinary(Binary.Skip(24).Take(8).ToArray());

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
            accum.AddRange(Utils.GetBinaryRepresentation(firstOctet));
            accum.AddRange(Utils.GetBinaryRepresentation(secondOctet));
            accum.AddRange(Utils.GetBinaryRepresentation(thirdOctet));
            accum.AddRange(Utils.GetBinaryRepresentation(fourthOctet));
            Binary = accum.ToArray();
        }

        public bool[] ToBinary()
        {
            bool[] firstOctetBin = Utils.GetBinaryRepresentation(FirstOctet);
            bool[] secondOctetBin = Utils.GetBinaryRepresentation(SecondOctet);
            bool[] thirdOctetBin = Utils.GetBinaryRepresentation(ThirdOctet);
            bool[] fourthOctetBin = Utils.GetBinaryRepresentation(FourthOctet);
            
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
            if (first.FirstOctet < second.FirstOctet)
                return true; 
            if (first.FirstOctet > second.FirstOctet)
                return false;
            if (first.SecondOctet < second.SecondOctet)
                return true; 
            if (first.SecondOctet > second.SecondOctet)
                return false;
            if (first.ThirdOctet < second.ThirdOctet)
                return true; 
            if (first.ThirdOctet > second.ThirdOctet)
                return false;
            return first.FourthOctet < second.FourthOctet;
        } 
        public static bool operator>(Ipv4Address first, Ipv4Address second)
        {
            return second < first;
        }
        
        public static bool operator<=(Ipv4Address first, Ipv4Address second)
        {
            if (first.FirstOctet > second.FirstOctet)
                return false;
            if (first.FirstOctet < second.FirstOctet)
                return true;
            if (first.SecondOctet < second.SecondOctet)
                return true; 
            if (first.SecondOctet > second.SecondOctet)
                return false;
            if (first.ThirdOctet < second.ThirdOctet)
                return true; 
            if (first.ThirdOctet > second.ThirdOctet)
                return false;
            return first.FourthOctet <= second.FourthOctet;
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