namespace NetworkAdmin.Ipv4Class.Ipv4
{
    public class ClassA : IPv4ClassNetwork
    {
        public override string GetName()
        {
            return "A";
        }

        public override ushort GetNetworkPortion()
        {
            return 8;
        }
    }
}