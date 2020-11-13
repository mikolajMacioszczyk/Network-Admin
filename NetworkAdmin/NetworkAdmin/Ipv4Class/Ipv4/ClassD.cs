namespace NetworkAdmin.Ipv4Class.Ipv4
{
    public class ClassD : IPv4ClassNetwork
    {
        public override string GetName()
        {
            return "D";
        }

        public override ushort GetNetworkPortion()
        {
            return 0;
        }
    }
}