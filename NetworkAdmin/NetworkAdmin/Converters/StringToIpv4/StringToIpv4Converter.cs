using System;
using NetworkAdmin.Exceptions;
using NetworkAdmin.IpAddress.Ipv4;
using static NetworkAdmin.Validators.ConverterValidators.StringToIpValidator;

namespace NetworkAdmin.Converters.StringToIpv4
{
    public class StringToIpv4Converter : IStringToIpv4Converter
    {
        public Ipv4Address ConvertFromDecimal(string input)
        {
            ValidateStringNotNull(input);
            var octets = DivideByOctetsDecimal(input);
            ValidateOctetsDecimal(octets,input);
            return new Ipv4Address(octets.Item1, octets.Item2, octets.Item3, octets.Item4);
        }
        
        private (ushort,ushort,ushort,ushort) DivideByOctetsDecimal(string input)
        {
            var splited = input.Split('.');
            ValidateLength(splited, 4);

            try
            {
                var firstOctet = ushort.Parse(splited[0]);
                var secondOctet = ushort.Parse(splited[1]);
                var thirdOctet = ushort.Parse(splited[2]);
                var fourthOctet = ushort.Parse(splited[3]);
                return (firstOctet, secondOctet, thirdOctet, fourthOctet);
            }
            catch (ArgumentException)
            {
                throw new IncorrectIpv4AddressException(input, "value must be numeric");
            }
            catch (OverflowException)
            {
                throw new IncorrectIpv4AddressException(input, "value in octet cannot be negative");
            }
        }
        
        public Ipv4Address ConvertFromBinary(string input)
        {
            ValidateStringNotNull(input);
            var bits = DivideByOctetsBinary(input);
            return new Ipv4Address(bits);
        }

        private bool[] DivideByOctetsBinary(string input)
        {
            var splitted = input.Split('.');
            ValidateLength(splitted, 4);
            try
            {
                return ConvertOctetsToBinary(splitted);
            }
            catch (IndexOutOfRangeException)
            {
                throw new IncorrectIpv4AddressException(input, "IpAddress must consist of 4 octets each with 8 bit");
            }
        }

        private bool[] ConvertOctetsToBinary(string[] splitted)
        {
            var output = new bool[32];
            int idx = 0;
            foreach (var octet in splitted)
            {
                for (int i = 0; i < 8; i++)
                {
                    switch (octet[i])
                    {
                        case '1':
                            output[idx++] = true;
                            break;
                        case '0':
                            output[idx++] = false;
                            break;
                        default:
                            throw new IncorrectIpv4AddressException(string.Join('.', splitted), "Each octet must consist of values 0 or 1");
                    }
                }
            }
            return output;
        }
    }
}