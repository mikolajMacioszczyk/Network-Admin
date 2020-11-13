using NetworkAdmin.IpAddress.Ipv4;

namespace NetworkAdmin.Ipv4Class.Ipv4
{
    public abstract class IPv4ClassNetwork: IClassNetwork<Ipv4Address>
    {
        public abstract string GetName();
        
        public abstract ushort GetNetworkPortion();

        protected bool Equals(IPv4ClassNetwork other)
        {
            return GetName() == other.GetName();
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IPv4ClassNetwork) obj);
        }

        public override int GetHashCode()
        {
            return GetName().GetHashCode();
        }

        public static bool operator ==(IPv4ClassNetwork left, IPv4ClassNetwork right)
        {
            if (ReferenceEquals(left, null)) return false;
            if (ReferenceEquals(right, null)) return false;
            if (ReferenceEquals(left, right)) return true;
            if (left.GetType() != right.GetType()) return false;
            return left.GetName() == right.GetName();
        }
        
        public static bool operator !=(IPv4ClassNetwork left, IPv4ClassNetwork right)
        {
            return !(left == right);
        }
    }
}