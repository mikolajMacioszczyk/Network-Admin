using System.Collections.Generic;
using NetworkAdmin.IpAddress.Ipv4;

namespace NetworkAdmin.IpAddress.Range.IPv4
{
    public abstract class Ipv4Range: IPRange<Ipv4Address>
    {
        public abstract IEnumerable<(Ipv4Address, Ipv4Address)> GetBoundaries();
        public abstract string Type();

        public static bool operator ==(Ipv4Range left, Ipv4Range right)
        {
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }
            return left.Type() == right.Type();
        }
        
        public static bool operator !=(Ipv4Range left, Ipv4Range right)
        {
            return !(left == right);
        }

        protected bool Equals(Ipv4Range other)
        {
            return Type() == other.Type();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ipv4Range) obj);
        }

        public override int GetHashCode()
        {
            return Type().GetHashCode();
        }
    }
}