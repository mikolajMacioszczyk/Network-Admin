using System;
using NetworkAdmin.Helpers;
using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.Ipv4Class.Ipv4;

namespace NetworkAdmin.Ipv4Class
{
    public class Ipv4ClassNetworkManager : IClassNetworkManager<Ipv4Address>
    {
        public static Ipv4Address ClassAMin = new Ipv4Address(1,0,0,0);
        public static Ipv4Address ClassAMax = new Ipv4Address(126,0,0,0);
        public static Ipv4Address ClassBMin = new Ipv4Address(128,1,0,0);
        public static Ipv4Address ClassBMax = new Ipv4Address(191,254,0,0);
        public static Ipv4Address ClassCMin = new Ipv4Address(192,0,1,0);
        public static Ipv4Address ClassCMax = new Ipv4Address(223,255,254,0);
        public static Ipv4Address ClassDMin = new Ipv4Address(224,0,0,0);
        public static Ipv4Address ClassDMax = new Ipv4Address(239,255,255,255);
        public static Ipv4Address ClassEMin = new Ipv4Address(240,0,0,0);
        public static Ipv4Address ClassEMax = new Ipv4Address(255,255,255,255);

        IClassNetwork<Ipv4Address> IClassNetworkManager<Ipv4Address>.GetClass(Ipv4Address address)
        {
            if (address >= ClassAMin && address <= ClassAMax) return new ClassA();
            if (address >= ClassBMin && address <= ClassBMax) return new ClassB();
            if (address >= ClassCMin && address <= ClassCMax) return new ClassC();
            if (address >= ClassDMin && address <= ClassDMax) return new ClassD();
            if (address >= ClassEMin && address <= ClassEMax) return new ClassE();
            return new ClassSpecial();
        }

        public ushort SubnetBitCount(IClassNetwork<Ipv4Address> networkClass, ushort networkPortion)
        {
            switch (networkClass.GetName())
            {
                case "A":
                case "B":
                case "C":
                    return networkPortion >= networkClass.GetNetworkPortion() && networkPortion < 32 ? 
                        (ushort)(networkPortion - networkClass.GetNetworkPortion()) : (ushort)0;
                default:
                    return 0;
            }
        }

        public ushort HostBitCount(IClassNetwork<Ipv4Address> networkClass, ushort networkPortion)
        {
            switch (networkClass.GetName())
            {
                case "A":
                case "B":
                case "C":
                    return networkPortion >= networkClass.GetNetworkPortion() && networkPortion < 32 ? (ushort)(32 - networkPortion) : (ushort)0;
                default:
                    return 0;
            }
        }

        public int PossibleSubnetCount(IClassNetwork<Ipv4Address> networkClass, ushort networkPortion)
        {
            switch (networkClass.GetName())
            {
                case "A":
                case "B":
                case "C":
                    return networkPortion >= networkClass.GetNetworkPortion() && networkPortion < 32 ? 
                        MathHelper.Pow(2,networkPortion - networkClass.GetNetworkPortion()) : 0;
                default:
                    return 0;
            }
        }
        
        public int PossibleHostsCount(IClassNetwork<Ipv4Address> networkClass, in ushort networkPortion)
        {
            switch (networkClass.GetName())
            {
                case "A":
                case "B":
                case "C":
                    return networkPortion >= networkClass.GetNetworkPortion() && networkPortion < 32 ? 
                        MathHelper.Pow(2,32 - networkPortion)-2 : 0;
                default:
                    return 0;
            }
        }

        public bool IsNetworkPortionValid(IClassNetwork<Ipv4Address> networkClass, ushort networkPortion)
        {
            if (networkPortion > 30)
            {
                return false;
            }
            switch (networkClass.GetName())
            {
                case "A":
                case "B":
                case "C":
                    return networkPortion >= networkClass.GetNetworkPortion();
                default:
                    return true;
            }
        }
    }
}