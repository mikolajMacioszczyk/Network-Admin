namespace NetworkAdmin.Ipv4Class.Ipv4
{
    public class ClassC: IPv4ClassNetwork
    {
        public override string GetName()
        {
            return "C";
        }

        public override ushort GetNetworkPortion()
        {
            return 24;
        }
    }
}