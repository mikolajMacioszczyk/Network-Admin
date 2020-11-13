namespace NetworkAdmin.IpAddress
{
    public interface IPAddress
    {
        public bool[] ToBinary();
        public ushort[] ToDecimal();
        public string ToDecimalString();
        public string ToBinaryString();
    }
}