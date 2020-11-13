namespace NetworkAdmin.Ipv4Class.Ipv4
{
    public class ClassSpecial: IPv4ClassNetwork
    {
        public override string GetName()
        {
            return "Special";
        }

        public override ushort GetNetworkPortion()
        {
            return 0;
        }
    }
}