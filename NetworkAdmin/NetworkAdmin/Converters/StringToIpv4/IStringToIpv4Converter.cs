using NetworkAdmin.IpAddress.Ipv4;

namespace NetworkAdmin.Converters.StringToIpv4
{
    public interface IStringToIpv4Converter
    {
        Ipv4Address ConvertFromDecimal(string input);
        Ipv4Address ConvertFromBinary(string input);
    }
}