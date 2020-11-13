using System;
using Microsoft.VisualBasic.CompilerServices;
using NetworkAdmin.ConsoleApp.Helpers;
using NetworkAdmin.Exceptions;
using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.IpAddress.Utils;
using NetworkAdmin.Ipv4Class;
using NetworkAdmin.Network;

namespace NetworkAdmin.ConsoleApp.Actions
{
    public class CheckIpv4AddressActions
    {
        private static readonly IPAddressUtils<Ipv4Address> Utils = new Ipv4AddressUtils();
        private static readonly INetworkManager<Ipv4Address> NetworkManager = new Ipv4NetworkManager();
        private static readonly IClassNetworkManager<Ipv4Address> ClassManager = new Ipv4ClassNetworkManager();
        private readonly IKeyboardInteraction _keyboardInteraction;

        public CheckIpv4AddressActions(IKeyboardInteraction keyboardInteraction)
        {
            _keyboardInteraction = keyboardInteraction;
        }

        public string GetClassAddress()
        {
            var address = GetAddressFromUser();
            var networkClass = ClassManager.GetClass(address);
            if (networkClass.GetName() != "Special")
            {
                return "Address belong to the class " + networkClass.GetName();
            }
            return "This is special address";
        }
        
        public string GetLastHostAddress()
        {
            return GetNetworkSpecialAddressInfo("Type address that belong to network. It may be host, network, broadcast",
                NetworkManager.GetLastHostAddress,
                "Last host address = ");
        }

        public string GetFirstHostAddress()
        {
            return GetNetworkSpecialAddressInfo("Type address that belong to network. It may be host, network, broadcast",
                NetworkManager.GetFirstHostAddress,
                "First host address = ");
        }

        public string GetBroadcastAddress()
        {
            return GetNetworkSpecialAddressInfo("Type address that belong to network. It may be host, network, broadcast",
                NetworkManager.GetBroadcastAddress,
                "Broadcast address = ");
        }

        public string GetNetworkAddress()
        {
            return GetNetworkSpecialAddressInfo("Type address that belong to network. It may be host, network, broadcast",
                NetworkManager.GetNetworkAddress,
                "Network address = ");
        }
        
        public string ServeGetAddressType()
        {
            var address = GetAddressFromUser();
            var type = Utils.GetAddressRange(address);
            return "Address type: "+type.Type();
        }

        public string ServeIsHostValid()
        {
            var (address, networkPortion) = GetAddressAndValidNetworkPortion();
            var result = Utils.IsLegalHostAddress(address, networkPortion);
            if (result)
            {
                return "Host address is correct.";
            }

            return "Host address is incorrect.";
        }
        
        public string SubnetNetworkBitCount()
        {
            var (address, networkPortion) = GetAddressAndValidNetworkPortion();
            var result = ClassManager.SubnetBitCount(ClassManager.GetClass(address), networkPortion);
            return "Subnet network bit count = " + result;
        }
        
        public string GetHostBitCount()
        {
            var (address, networkPortion) = GetAddressAndValidNetworkPortion();
            var result = ClassManager.HostBitCount(ClassManager.GetClass(address), networkPortion);
            return "Host bit count = " + result;
        }

        private (Ipv4Address, ushort) GetAddressAndValidNetworkPortion()
        {
            var address = GetAddressFromUser();
            var networkPortion = GetNetworkPortion();
            while (!Utils.IsValidNetworkPortion(address,networkPortion))
            {
                Console.WriteLine("Incorrect network portion");
                networkPortion = GetNetworkPortion();
            }
            return (address, networkPortion);
        }
        
        private string GetNetworkSpecialAddressInfo(string introMessage, Func<Ipv4Address, ushort, Ipv4Address> addressResolver, string outputMessage)
        {
            Console.WriteLine(introMessage);
            var address = GetAddressFromUser();
            var networkPortion = GetNetworkPortion();
            while (!Utils.IsValidNetworkPortion(address, networkPortion))
            {
                Console.WriteLine("Incorrect network portion");
                GetNetworkPortion();
            }
            var networkAddress = addressResolver(address, networkPortion);
            return outputMessage+networkAddress.ToDecimalString();
        }

        private ushort GetNetworkPortion()
        {
            return GetInput<ushort, ArgumentException>("Network Portion: ", ushort.Parse, GetNetworkPortion);
        }
        
        private Ipv4Address GetAddressFromUser()
        {
            return GetInput<Ipv4Address, IncorrectIpv4AddressException>(
                "Type Ipv4Address: ", 
                NetworkManager.GetAddressFromDecimalString, GetAddressFromUser);
        }

        private T GetInput<T, E>(string message, Func<string, T> castFunction, Func<T> failCallback) where E : Exception
        {
            Console.Write(message);
            var input = _keyboardInteraction.ReadString();
            try
            {
                var result = castFunction(input);
                return result;
            }
            catch (E e)
            {
                return failCallback();
            }
        }
    }
}