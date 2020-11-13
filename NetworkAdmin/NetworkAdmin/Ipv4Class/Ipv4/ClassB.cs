namespace NetworkAdmin.Ipv4Class.Ipv4
{
    public class ClassB: IPv4ClassNetwork
    {
        public override string GetName()
        {
            return "B";
        }

        public override ushort GetNetworkPortion()
        {
            return 16;
        }
    }
}