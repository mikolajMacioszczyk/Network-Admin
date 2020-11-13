using NetworkAdmin.Exceptions;

namespace NetworkAdmin.Validators.ConverterValidators
{
    public static class StringToIpValidator
    {
        public static void ValidateOctetsDecimal((ushort,ushort,ushort,ushort) octets, string original)
        {
            if (octets.Item1 >= 256 || octets.Item2 >= 256 || octets.Item3 >= 256 || octets.Item4 >= 256)
            {
                throw new IncorrectIpv4AddressException(original, "Value in single octet cannot be greater than 255");
            }
        }

        public static void ValidateStringNotNull(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new IncorrectIpv4AddressException(input, "Value cannot be empty");
            }
        }

        public static void ValidateLength<T>(T[] array, int expectedSize)
        {
            if (array.Length != expectedSize)
            {
                throw new IncorrectIpv4AddressException(string.Join('.', array), "IPv4 address must consist of 4 octets");
            }
        }
    }
}