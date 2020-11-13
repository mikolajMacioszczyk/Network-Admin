using System;
using NetworkAdmin.ConsoleApp.Helpers;
using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.IpAddress.Utils;
using NetworkAdmin.Network;

namespace NetworkAdmin.ConsoleApp.Managers
{
    public class SubnetMaskOfNetworkActionManager: IActionManager
    {
        private static readonly INetworkManager<Ipv4Address> NetworkManager = new Ipv4NetworkManager(); 
        private static readonly IPAddressUtils<Ipv4Address> Utils = new Ipv4AddressUtils();
        private readonly IKeyboardInteraction _keyboardInteraction;

        public SubnetMaskOfNetworkActionManager(IKeyboardInteraction keyboardInteraction)
        {
            _keyboardInteraction = keyboardInteraction;
        }

        private void ShowMenu()
        {
            Console.WriteLine("============= Subnet Mask Menu =============");
            Console.WriteLine("1. In Decimal");
            Console.WriteLine("2. In Binary");
            Console.WriteLine("-1. Back");
        }
        public int Run()
        {
            var state = int.MinValue;
            while (state != -1)
            {
                ShowMenu();
                state = _keyboardInteraction.ReadNumber();
                switch (state)
                {
                    case 1:
                        ServeDecimal();
                        break;
                    case 2:
                        ServeBinary();
                        break;
                    case -1:
                        break;
                    default:
                        Console.WriteLine(state+" is not an option");
                        break;
                }
            }
            return state;
        }

        private ushort GetValidNetworkPortion()
        {
            ushort networkPortion = GetNetworkPortion();
            while (networkPortion < 8 || networkPortion >= 32)
            {
                Console.WriteLine("Network Portion must be value between 8 and 32");
                networkPortion = GetNetworkPortion();
            }
            return networkPortion;
        }

        private Ipv4Address GetMaskOfNetworkPortion(ushort networkPortion)
        {
            
            var mask = new Ipv4Address(0,0,0,0);
            for (int i = 0; i < networkPortion; i++)
            {
                mask[i] = true;
            }

            return mask;
        }

        private void ServeBinary()
        {
            var networkPortion = GetValidNetworkPortion();
            var mask = GetMaskOfNetworkPortion(networkPortion);
            Console.WriteLine("Subnet mask:");
            Console.WriteLine("Binary = "+mask.ToBinaryString());
        }

        private void ServeDecimal()
        {
            var networkPortion = GetValidNetworkPortion();
            var mask = GetMaskOfNetworkPortion(networkPortion);
            Console.WriteLine("Subnet mask:");
            Console.WriteLine("Decimal = "+mask.ToDecimalString());
        }

       private ushort GetNetworkPortion()
        {
            return GetInput<ushort, ArgumentException>(
                "Please, enter network portion length: ",
                ushort.Parse,
                "Value must be numeric.",
                GetNetworkPortion
            );
        }
        
        private T GetInput<T, E>(string message, Func<string, T> converter, string failureMessage, Func<T> setBackFunction) where E : Exception
        {
            Console.Write(message);
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return setBackFunction();
            }
            try
            {
                var result = converter(input);
                return result;
            }
            catch (E e)
            {
                Console.WriteLine(failureMessage);
                return setBackFunction();
            }
        }
    }
}